using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphics1
{
    public static class MyGeometry
    {
        public static int CrossProduct(Point p1, Point p2, Point p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
        }

        public static List<Point> ConvexHull(List<Point> P)
        {
            int n = P.Count, k = 0;
            Point[] H = new Point[2 * n];
            P = P.OrderBy(p => p.X).ToList();
            for (int i = 0; i < n; i++)
            {
                while (k >= 2 && MyGeometry.CrossProduct(H[k - 2], H[k - 1], P[i]) <= 0) k--;
                H[k++] = P[i];
            }
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && MyGeometry.CrossProduct(H[k - 2], H[k - 1], P[i]) <= 0) k--;
                H[k++] = P[i];
            }
            List<Point> list = new List<Point>();
            for (int i = 0; i < k - 1; i++)
                list.Add(H[i]);
            return list;
        }

        public static bool IsPointInside(List<Point> poly, Point p)
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

        public static  bool IsPolyPointClicked(Point circle, Point p)
        {
            return (p.X - circle.X) * (p.X - circle.X) + (p.Y - circle.Y) * (p.Y - circle.Y) <= 15;
        }
    }
}
