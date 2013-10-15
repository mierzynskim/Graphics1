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

        public List<Point> Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private int _thickness;

        public int Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }

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


                bitmap.SetPixel(currentPoint.X, currentPoint.Y, Color.Black);

                if (dx > dy)
                {
                    //Debug.WriteLine("xi: {0} yi: {1} number {2} dx > dy", xi, yi, pointsClicked);
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
                        bitmap.SetPixel(currentPoint.X, currentPoint.Y, Color.Black);


                    }


                }
                else
                {
                    //Debug.WriteLine("xi: {0} yi: {1} number {2} dx <= dy", xi, yi, pointsClicked);
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
                        bitmap.SetPixel(currentPoint.X, currentPoint.Y, Color.Black);
                    }

                }

                graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            }
            //graphics.Dispose();
        }

        public void Draw(Size pictureBox, Graphics e)
        {

            for (int i = 0; i < Points.Count - 1; i++)
            {
                Bresenham(Points[i], Points[i + 1], pictureBox, e);
            }
            Bresenham(Points[0], Points[Points.Count - 1], pictureBox, e);

        }
    }
}
