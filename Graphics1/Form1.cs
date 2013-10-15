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
        private int? selectedId = null;

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

            if (newPolygon.Checked)
            {

                if (pointsClicked == 0)
                {
                    polygons.Add(new Polygon());
                    polygons.Last().Points = new List<Point>();
                    polygons.Last().IsFinished = false;
                }

                polygons.Last().Points.Add(pictureLocation);

                pointsClicked++;
                
            }
            else
            {
                polygons[(int)selectedId].Points.Add(pictureLocation);
            }

            pictureBox.Invalidate();
        }

        private void DrawPoint(Point location, Graphics graphics, Color color)
        {

            var rectangle = new Rectangle(location.X - 5, location.Y - 5, 10, 10);
            var myBrush = new SolidBrush(color);
            graphics.FillEllipse(myBrush, rectangle);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (newPolygon.Checked)
            {
                listView.Items.Add(String.Format("Wielokąt nr {0} o {1} wierzchołkach", currentPolygon + 1, pointsClicked));
                pointsClicked = 0;
                polygons.Last().IsFinished = true;
                pictureBox.Invalidate();
                currentPolygon++;

            }
            else
            {
                
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (polygons.Count != 0)
            {
                Graphics g = e.Graphics;

                foreach (var poly in polygons)
                {
                    foreach (var point in poly.Points)
                    {
                        DrawPoint(point, g, !poly.IsSelected ? Color.Red : Color.Blue);

                    }
                    if (poly.IsFinished)
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

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ListViewItem i in listView.Items)
            {
                if (i.Selected) 
                {
                    if (selectedId != null)
                        polygons[(int)selectedId].IsSelected = false;
                    selectedId = i.Index;
                    polygons[(int)selectedId].IsSelected = true; 
                }
            }
            
            pictureBox.Invalidate();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (deletePolygon.Checked && selectedId != null)
            {
                int selected = (int)selectedId;
                selectedId = null;
                polygons.RemoveAt(selected);
                //listView.Items.RemoveAt(selected);
                
                pictureBox.Invalidate();
            }
        }





    }
}
