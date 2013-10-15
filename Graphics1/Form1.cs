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
        private Point pictureLocation;
        private List<Polygon> polygons = new List<Polygon>();
        private int pointsClicked;
        private int currentPolygon;

        private bool IsEdit = false;

        public List<Polygon> Polygons
        {
            get { return polygons; }
            set { polygons = value; }
        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs MouseE = (MouseEventArgs)e;
            pictureLocation = new Point(MouseE.X, MouseE.Y);

            if (pointsClicked == 0)
            {
                polygons.Add(new Polygon());
                polygons[currentPolygon].Points = new List<Point>();
            }

            polygons[currentPolygon].Points.Add(pictureLocation);

            pointsClicked++;
            pictureBox.Invalidate();
        }

        private void DrawPoint(Point location, Graphics graphics)
        {
            
            Rectangle rectangle = new System.Drawing.Rectangle(location.X - 5, location.Y - 5, 10, 10);
            SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            graphics.FillEllipse(myBrush, rectangle);

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

        private void addButton_Click(object sender, EventArgs e)
        {
            //polygons[currentPolygon].Draw(ref pictureBox);
            IsEdit = true;
            pictureBox.Invalidate();
            pointsClicked = 0;
            currentPolygon++;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            
            //TestMethod();
            currentPolygon++;
            pointsClicked = 0;

        }

        //private void TestMethod()
        //{
        //    for (int i = 1; i < polygons[currentPolygon].Points.Count; i++)
        //    {
        //        try
        //        {
        //            Polygon.Bresenham(polygons[currentPolygon].Points[0], polygons[currentPolygon].Points[i], ref pictureBox);
        //        }
        //        catch
        //        {
        //            continue;
        //        }
        //    }
        //}
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            //if (bitmap != null)
            //    e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            if (polygons.Count != 0)
            {
                Graphics g = e.Graphics;

                    foreach (var poly in polygons)
                    {
                        foreach (var point in poly.Points)
                        {
                            DrawPoint(point, g);

                        }
                        if (IsEdit)
                            poly.Draw(pictureBox.Size, g);
                    }


            }

            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //if (polygons.Count != 0)
            //{
            //    using (Graphics g = pictureBox.CreateGraphics())
            //    {
            //        foreach (var poly in polygons)
            //        {
            //            foreach (var point in poly.Points)
            //            {
            //                DrawPoint(point, g);

            //            }
            //            if (IsEdit)
            //                poly.Draw(pictureBox.Size, g);
            //        }
            //    }

            //}
        }





    }
}
