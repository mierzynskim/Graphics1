using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
