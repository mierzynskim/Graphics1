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

        private bool draggingPoint;
        private Point pointClicked;
        private Point polyPointClicked;

        private bool draggingPolygon;
        private Polygon selectedPolygon = null;

        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidatePoints(ref Point p, Size size)
        {
            int x = p.X, y = p.Y;
            bool change = false;
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x > size.Width - 5) x = size.Width - 1;
            if (y > size.Height - 5) y = size.Height - 1;
            if (x != p.X || y != p.Y) change = true;
            p = new Point(x, y);
            return change;
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
                try
                {
                    selectedPolygon.Points.Add(pictureLocation);
                    selectedPolygon.Points = MyGeometry.ConvexHull(selectedPolygon.Points);
                }
                catch
                {
                    MessageBox.Show("Nie wybrano wielokąta, w którym ma być dodany punkt.\nKliknij Zaznacz wielokąt lub dodaj nowy");
                }
            }
            else if (markPoly.Checked)
            {
                foreach (var poly in polygons)
                {
                    if (MyGeometry.IsPointInside(poly.Points, pictureLocation))
                    {
                        if (selectedPolygon != null)
                            selectedPolygon.IsSelected = false;
                        poly.IsSelected = true;
                        selectedPolygon = poly;
                        break;
                    }
                }
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
                        ValidatePoints(ref pointMoveTo, pictureBox.Size);
                        
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
            if (selectedPolygon != null && movePolygon.Checked)
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
                        if (MyGeometry.IsPolyPointClicked(point, pointClicked))
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
                        if (MyGeometry.IsPointInside(poly.Points, pointClicked))
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
            else if (deletePoint.Checked)
            {
                bool isDeleted = false;
                foreach (var poly in polygons)
                {
                    foreach (var point in poly.Points)
                    {
                        if (MyGeometry.IsPolyPointClicked(point, pointClicked))
                        {
                            poly.Points.Remove(point);
                            if (poly.Points.Count == 0)
                                polygons.Remove(poly);
                            pictureBox.Invalidate();
                            isDeleted = true;
                            break;
                        }

                    }
                    if (isDeleted)
                        break;
                }

            }

        }
        #endregion

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
                try
                {
                    pointsClickedCounter = 0;
                    polygons.Last().IsFinished = true;
                    polygons.Last().Points = MyGeometry.ConvexHull(polygons.Last().Points);
                    pictureBox.Invalidate();
                    currentPolygon++;
                }
                catch
                {
                    MessageBox.Show("Nie dodano punktów");
                }

            }
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            if (deletePolygon.Checked && selectedPolygon != null)
            {
                polygons.Remove(selectedPolygon);
                selectedPolygon = null;
                pictureBox.Invalidate();
            }
        }

        private void ChangeColorClick(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            try
            {
                if (MyDialog.ShowDialog() == DialogResult.OK)
                    selectedPolygon.Color = MyDialog.Color;
            }
            catch
            {
                MessageBox.Show("Nie wybrano wielokąta.\nKliknij Zaznacz wielokąt, aby zmienić kolor");
            }
            pictureBox.Invalidate();
        }

        private void thicknessBar_Scroll(object sender, EventArgs e)
        {
            try
            {
                selectedPolygon.Thickness = thicknessBar.Value;
                pictureBox.Invalidate();
            }
            catch
            {
                thicknessBar.Value--;
                MessageBox.Show("Nie wybrano wielokąta.\nKliknij Zaznacz wielokąt, aby zmienić kolor");
            }

        }




    }
}
