using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics1
{
    class PolarAngleComparer : IComparer<Point>
    {
        private Point point0;

        /// <summary>
        /// Creates an instance of PolarAngleComparer
        /// </summary>
        /// <param name="point0">the zero (top left) point</param>
        public PolarAngleComparer(Point point0)
        {
            this.point0 = point0;
        }

        /// <summary>
        /// Compares 2 point values in order to determine the one with minimal polar angle to given zero point
        /// </summary>
        /// <param name="a">first point</param>
        /// <param name="b">second point</param>
        /// <returns>a<b => value < 0; a==b => value == 0; a>b => value > 0</returns>
        public int Compare(Point a, Point b)
        {
            double angle1 = Math.Atan2(a.Y - point0.Y, a.X - point0.X);
            double angle2 = Math.Atan2(b.Y - point0.Y, b.X - point0.X);

            int ang1 = (int)(angle1 * 100);
            int ang2 = (int)(angle2 * 100);
            if (ang1 < ang2) return -1;
            else if (ang1 > ang2) return 1;
            return 0;
        }


    }
}
