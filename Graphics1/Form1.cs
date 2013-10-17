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
        private int pointsClickedCounter;
        private int currentPolygon;
        private int? selectedId = null;

        private bool draggingPoint;
        private Point pointClicked;
        private Point polyPointClicked;

        private bool draggingPolygon;
        private Polygon selectedPolygon;

        public List<Polygon> Polygons
        {
            get { return polygons; }
            set { polygons = value; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        #region Picture Box events
        private void PictureBoxClick(object sender, EventArgs e)
        {
            MouseEventArgs MouseE = (MouseEventArgs)e;
            pictureLocation = new Point(MouseE.X, MouseE.Y);

            if (newPolygon.Checked)
            {

                if (pointsClickedCounter == 0)
                {
                    polygons.Add(new Polygon());
                    polygons.Last().Points = new List<Point>();
                    polygons.Last().IsFinished = false;
                }

                polygons.Last().Points.Add(pictureLocation);

                pointsClickedCounter++;

            }
            else if (newPoint.Checked)
            {
                polygons[(int)selectedId].Points.Add(pictureLocation);
            }


            pictureBox.Invalidate();
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
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

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (draggingPoint)
            {
                Point pointMoveTo = new Point(polyPointClicked.X + e.X, polyPointClicked.Y + e.Y);
                pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);

                foreach (var poly in polygons)
                {
                    for (int i = 0; i < poly.Points.Count; i++)
                    {
                        if (polyPointClicked == poly.Points[i])
                        {
                            poly.Points[i] = new Point(pointMoveTo.X, pointMoveTo.Y);
                            polyPointClicked = new Point(pointMoveTo.X, pointMoveTo.Y);
                            pointClicked = new Point(pointMoveTo.X, pointMoveTo.Y);
                            break;
                        }
                    }

                }
                pictureBox.Invalidate();
            }
            else if (draggingPolygon)
            {
                for (int i = 0; i < selectedPolygon.Points.Count; i++)
                {
                    Point pointMoveTo = new Point(selectedPolygon.Points[i].X + e.X, selectedPolygon.Points[i].Y + e.Y);
                    pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);
                    selectedPolygon.Points[i] = new Point(pointMoveTo.X, pointMoveTo.Y);
                }
                pointClicked = new Point(e.X, e.Y);
                pictureBox.Invalidate();
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            draggingPoint = false;
            draggingPolygon = false;
            this.Cursor = Cursors.Default;
            if (selectedPolygon != null)
                selectedPolygon.IsSelected = false;
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            pointClicked = new Point(e.X, e.Y);
            if (movePoint.Checked)
            {
                bool isPolyPointClicked = false;
                foreach (var poly in polygons)
                {
                    foreach (var point in poly.Points)
                    {
                        if (IsPolyPointClicked(point, pointClicked))
                        {
                            isPolyPointClicked = true;
                            polyPointClicked = point;
                        }

                    }

                }

                if (e.Button == MouseButtons.Left && isPolyPointClicked)
                    draggingPoint = true;
            }
            else if (movePolygon.Checked)
            {
                bool isInsidePoly = false;
                this.Cursor = Cursors.NoMove2D;
                foreach (var poly in polygons)
                {
                    foreach (var point in poly.Points)
                    {
                        if (IsPointInside(poly.Points, pointClicked))
                        {
                            poly.IsSelected = true;
                            isInsidePoly = true;
                            selectedPolygon = poly;
                        }
                    }
                }
                if (e.Button == MouseButtons.Left && isInsidePoly)
                    draggingPolygon = true;
            }

        }
        #endregion

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

        private void DrawPoint(Point location, Graphics graphics, Color color)
        {
            var rectangle = new Rectangle(location.X - 5, location.Y - 5, 10, 10);
            var myBrush = new SolidBrush(color);
            graphics.FillEllipse(myBrush, rectangle);

        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (newPolygon.Checked)
            {
                listView.Items.Add(String.Format("Wielokąt nr {0} o {1} wierzchołkach", currentPolygon + 1, pointsClickedCounter));
                pointsClickedCounter = 0;
                polygons.Last().IsFinished = true;
                pictureBox.Invalidate();
                currentPolygon++;

            }
            else
            {

            }
        }

        private void DeleteButtonClick(object sender, EventArgs e)
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

        private bool IsPolyPointClicked(Point circle, Point p)
        {
            return (p.X - circle.X) * (p.X - circle.X) + (p.Y - circle.Y) * (p.Y - circle.Y) <= 10;
        }

        private bool IsPointInside(List<Point> poly, Point p)
        {
            int k, j = poly.Count - 1;
            bool oddNodes = false;
            for (k = 0; k < poly.Count; k++)
            {
                Point polyK = poly[k];
                Point polyJ = poly[j];

                if (((polyK.Y > p.Y) != (polyJ.Y > p.Y)) &&
                 (p.X < (polyJ.X - polyK.X) * (p.Y - polyK.Y) / (polyJ.Y - polyK.Y) + polyK.X))
                    oddNodes = !oddNodes;
                j = k;
            }

            return oddNodes;
        }






    }
}
