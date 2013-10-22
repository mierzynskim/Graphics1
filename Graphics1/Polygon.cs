using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;

namespace Graphics1
{
    public class Polygon
    {
        private List<Point> _points;
        private bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private int _thickness = 1;

        public bool IsFinished { get; set; }

        public int Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }

        private Color color = Color.Black;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool BresenhamMode { get; set; }
        public bool WUmode { get; set; }


        private void Bresenham(Point startPoint, Point endPoint, Size pictureBox, Graphics graphics)
        {
            using (Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height))
            {
                int xi = 0, yi = 0, dx = 0, dy = 0, d;
                Point currentPoint = new Point(startPoint.X, startPoint.Y);

                if (startPoint.X < endPoint.X)
                {
                    xi = 1;
                    dx = endPoint.X - startPoint.X;
                }
                else if (startPoint.X > endPoint.X)
                {
                    xi = -1;
                    dx = startPoint.X - endPoint.X;
                }

                if (startPoint.Y < endPoint.Y)
                {
                    yi = 1;
                    dy = endPoint.Y - startPoint.Y;
                }
                else if (startPoint.Y > endPoint.Y)
                {
                    yi = -1;
                    dy = startPoint.Y - endPoint.Y;
                }


                bitmap.SetPixel(currentPoint.X, currentPoint.Y, color);

                if (dx > dy)
                {
                    int incr1 = 2 * dy;
                    int incr2 = 2 * (dy - dx);
                    d = incr1 - dx;
                    while (currentPoint.X != endPoint.X)
                    {
                        if (d < 0)
                        {
                            d += incr1;
                            currentPoint.X += xi;
                        }
                        else
                        {
                            d += incr2;
                            currentPoint.Y += yi;
                            currentPoint.X += xi;
                        }
                        bitmap.SetPixel(currentPoint.X, currentPoint.Y, color);
                    }
                }
                else
                {
                    int incr1 = 2 * dx;
                    int incr2 = 2 * (dx - dy);
                    d = incr1 - dy;
                    while (currentPoint.Y != endPoint.Y)
                    {
                        if (d < 0)
                        {
                            d += incr1;
                            currentPoint.Y += yi;
                        }
                        else
                        {
                            d += incr2;
                            currentPoint.Y += yi;
                            currentPoint.X += xi;
                        }
                        bitmap.SetPixel(currentPoint.X, currentPoint.Y, color);
                    }
                }

                graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            }
        }

        public void Draw(Size pictureBox, Graphics e)
        {
            if (BresenhamMode)
            {
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    for (int j = 0; j < Thickness; j++)
                        Bresenham(new Point(Points[i].X + j, Points[i].Y), new Point(Points[i + 1].X + j, Points[i + 1].Y), pictureBox, e);
                }
                for (int j = 0; j < Thickness; j++)
                    Bresenham(new Point(Points[0].X + j, Points[0].Y), new Point(Points[Points.Count - 1].X + j, Points[Points.Count - 1].Y), pictureBox, e);
            }
            else
            {
                for (int i = 0; i < Points.Count - 1; i++)
                    for (int j = 0; j < Thickness; j++)
                        WuAlgorithm(new Point(Points[i].X + j, Points[i].Y), new Point(Points[i + 1].X + j, Points[i + 1].Y), pictureBox, e, false);
                for (int j = 0; j < Thickness; j++)
                    WuAlgorithm(new Point(Points[0].X + j, Points[0].Y), new Point(Points[Points.Count - 1].X + j, Points[Points.Count - 1].Y), pictureBox, e, false);
            }

        }

        private void ValidatePoints(ref Point p1, ref Point p2, Size size)
        {
            p1 = new Point(Math.Abs(p1.X) % size.Width, Math.Abs(p1.Y) % size.Height);
            p2 = new Point(Math.Abs(p2.X) % size.Width, Math.Abs(p2.Y) % size.Height);
        }

        public void MySetPixel(Bitmap bitmap, int x, int y, double br)
        {
            int r, g, b;
            r = (int)(color.R * br);
            g = (int)(color.G * br);
            b = (int)(color.B * br);
            Color col;
            col = Color.FromArgb(r, g, b);
            if (x >= 0 && x < bitmap.Width && y >= 0 && y < bitmap.Height)
                bitmap.SetPixel(x, y, col);
        }

        public int ipart(double x)
        {
            return (int)x;
        }

        public int round(double x)
        {
            return ipart(x + 0.5);
        }

        public double fpart(double x)
        {
            return x - ipart(x);
        }

        public double rfpart(double x)
        {
            return 1 - fpart(x);
        }

        public void WuAlgorithm(Point startPoint, Point endPoint, Size pictureBox, Graphics graphics, bool ch)
        {
            using (Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height))
            {
                bool steep = Math.Abs(endPoint.Y - startPoint.Y) > Math.Abs(endPoint.X - startPoint.X);
                int x1, y1, x2, y2, tmp;
                double gradient, xend, yend, xgap, xpxl1, ypxl1, intery, xpxl2, ypxl2, dx, dy;
                x1 = startPoint.X;
                y1 = startPoint.Y;
                x2 = endPoint.X;
                y2 = endPoint.Y;

                if (steep)
                {
                    tmp = x1;
                    x1 = y1;
                    y1 = tmp;
                    tmp = x2;
                    x2 = y2;
                    y2 = tmp;
                }
                if (x1 > x2)
                {
                    tmp = x1;
                    x1 = x2;
                    x2 = tmp;
                    tmp = y1;
                    y1 = y2;
                    y2 = tmp;
                }

                dx = x2 - x1;
                dy = y2 - y1;
                gradient = dy / dx;

                xend = round(x1);
                yend = y1 + gradient * (xend - x1);
                xgap = rfpart(x1 + 0.5);
                xpxl1 = xend;
                ypxl1 = ipart(yend);
                if (steep)
                {
                    MySetPixel(bitmap, (int)ypxl1, (int)xpxl1, rfpart(yend) * xgap);
                    MySetPixel(bitmap, (int)ypxl1 + 1, (int)xpxl1, fpart(yend) * xgap);
                }
                else
                {
                    MySetPixel(bitmap, (int)xpxl1, (int)ypxl1, rfpart(yend) * xgap);
                    MySetPixel(bitmap, (int)xpxl1, (int)ypxl1 + 1, fpart(yend) * xgap);
                }
                intery = yend + gradient;
                xend = round(x2);
                yend = y2 + gradient * (xend - x2);
                xgap = fpart(x2 + 0.5);
                xpxl2 = xend;
                ypxl2 = ipart(yend);
                if (steep)
                {
                    MySetPixel(bitmap, (int)ypxl2, (int)xpxl2, rfpart(yend) * xgap);
                    MySetPixel(bitmap, (int)ypxl2 + 1, (int)xpxl2, fpart(yend) * xgap);
                }
                else
                {
                    MySetPixel(bitmap, (int)xpxl2, (int)ypxl2, rfpart(yend) * xgap);
                    MySetPixel(bitmap, (int)xpxl2, (int)ypxl2 + 1, fpart(yend) * xgap);
                }

                for (int x = (int)(xpxl1 + 1); x <= xpxl2; ++x)
                {
                    if (steep)
                    {
                        MySetPixel(bitmap, ipart(intery), x, rfpart(intery));
                        MySetPixel(bitmap, ipart(intery) + 1, x, fpart(intery));
                    }
                    else
                    {
                        MySetPixel(bitmap, x, ipart(intery), rfpart(intery));
                        MySetPixel(bitmap, x, ipart(intery) + 1, fpart(intery));
                    }
                    intery = intery + gradient;
                }

                graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

            }
        }


    }
}
