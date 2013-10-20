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

        private void Bresenham(Point startPoint, Point endPoint, Size pictureBox, Graphics graphics)
        {
            using (Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height))
            {
                int xi = 0, yi = 0, dx = 0, dy = 0, d;
                //ValidatePoints(ref startPoint, ref endPoint, pictureBox);

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
            for (int i = 0; i < Points.Count - 1; i++)
            {
                for (int j = 0; j < Thickness; j++)
                    Bresenham(new Point(Points[i].X + j, Points[i].Y), new Point(Points[i + 1].X + j, Points[i + 1].Y), pictureBox, e);
            }
            for (int j = 0; j < Thickness; j++)
                    Bresenham(new Point(Points[0].X + j, Points[0].Y), new Point(Points[Points.Count - 1].X + j, Points[Points.Count - 1].Y), pictureBox, e);

        }

        private void ValidatePoints(ref Point p1, ref Point p2, Size size)
        {
            p1 = new Point(Math.Abs(p1.X) % size.Width, Math.Abs(p1.Y) % size.Height);
            p2 = new Point(Math.Abs(p2.X) % size.Width, Math.Abs(p2.Y) % size.Height);
        }


    }
}
