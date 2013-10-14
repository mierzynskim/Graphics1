using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace Graphics1
{
    public partial class Form1 : Form
    {
        private Point _pictureLocation;
        private List<Polygon> _polygons = new List<Polygon>();
        private int _pointsClicked;
        private int _currentPolygon;
        private Bitmap bitmap;

//#if (DEBUG)
//        private List<Point> lista = new List<Point>();
//        private int liczba;
//#endif

        public List<Polygon> Polygons
        {
            get { return _polygons; }
            set { _polygons = value; }
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs MouseE = (MouseEventArgs)e;
            _pictureLocation = new Point(MouseE.X, MouseE.Y);

            DrawPoint(_pictureLocation);
            //SetPixelEx(_pictureLocation);
        }

        private void DrawPoint(Point location)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            Rectangle rectangle = new System.Drawing.Rectangle(location.X - 5, location.Y - 5, 10, 10);
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            graphics.FillEllipse(myBrush, rectangle);

            if (_pointsClicked == 0)
            {
                _polygons.Add(new Polygon());
                _polygons[_currentPolygon].Points = new List<Point>();
            }

            _polygons[_currentPolygon].Points.Add(location);

            _pointsClicked++;

//#if (DEBUG)

//            liczba++;
//            lista.Add(location);

//            if (liczba >= 2)
//            {
//                    Bresenham(lista[lista.Count - 2], lista[lista.Count - 1]);
//            }
//#endif
   
        }

        private void SwapPoints(ref Point p1, ref Point p2)
        {
            Point temp = p1;
            p1 = new Point(p2.X, p2.Y);
            p2 = new Point(temp.X, temp.Y);
        }

        private void SwapXY(ref Point p1, ref Point p2)
        {
            int temp = p1.X;
            p1.X = p1.Y;
            p1.Y = temp;

            temp = p2.X;
            p2.X = p2.Y;
            p2.Y = temp;

        }

        private Point ConvertPoint(Point p)
        {
            return new Point(p.X, -p.Y);
        }

        private void Bresenham(Point startPoint, Point endPoint)
        {
            Graphics graphics = pictureBox.CreateGraphics();
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

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
                Debug.WriteLine("xi: {0} yi: {1} number {2} dx > dy", xi, yi, _pointsClicked); 
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
                Debug.WriteLine("xi: {0} yi: {1} number {2} dx <= dy", xi, yi, _pointsClicked); 
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

        private void addButton_Click(object sender, EventArgs e)
        {
            

            for (int i = 0; i < _polygons[_currentPolygon].Points.Count - 1; i++)
            {
                Bresenham(_polygons[_currentPolygon].Points[i], _polygons[_currentPolygon].Points[i + 1]);
            }
            Bresenham(_polygons[_currentPolygon].Points[0], _polygons[_currentPolygon].Points[_pointsClicked - 1]);
            _pointsClicked = 0;
            _currentPolygon++;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            
            TestMethod();
            _currentPolygon++;
            _pointsClicked = 0;

        }

        private void TestMethod()
        {
            for (int i = 1; i < _polygons[_currentPolygon].Points.Count; i++)
            {
                try
                {
                    Bresenham(_polygons[_currentPolygon].Points[0], _polygons[_currentPolygon].Points[i]);
                }
                catch
                {
                    continue;
                }
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap != null)
                e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            //if (_polygons.Count != 0)
            //{
            //    for (int i = 1; i < _polygons[0].Points.Count; i++)
            //    {
            //        try
            //        {
            //            Bresenham(_polygons[0].Points[0], _polygons[0].Points[i]);
            //        }
            //        catch
            //        {
            //            continue;
            //        }
            //    }
            //}
        }





    }
}
