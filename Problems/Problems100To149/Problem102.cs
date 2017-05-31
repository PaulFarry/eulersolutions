using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Problems100To149
{
    class Problem102 : IProblem
    {
        public int Number => 102;

        private struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }
        bool PointInsideTriangle(Point origin, List<Point> triangle)
        {
            return PointInsideTriangle(origin, triangle[0], triangle[1], triangle[2]);
        }

        bool PointInsideTriangle(Point s, Point a, Point b, Point c)
        {
            int as_x = s.X - a.X;
            int as_y = s.Y - a.Y;

            bool s_ab = (b.X - a.X) * as_y - (b.Y - a.Y) * as_x > 0;

            if ((c.X - a.X) * as_y - (c.Y - a.Y) * as_x > 0 == s_ab) return false;

            if ((c.X - b.X) * (s.Y - b.Y) - (c.Y - b.Y) * (s.X - b.X) > 0 != s_ab) return false;

            return true;
        }

        public string Execute()
        {
            var origin = new Point { X = 0, Y = 0 };

            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p102.txt";

            var inside = 0;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (true)
                {
                    var currentLine = reader.ReadLine();
                    if (string.IsNullOrEmpty(currentLine)) break;
                    var data = currentLine.Split(',');
                    var triangle = new List<Point>();
                    for (var i = 0; i < 6; i += 2)
                    {
                        var p1 = int.Parse(data[i]);
                        var p2 = int.Parse(data[i + 1]);

                        triangle.Add(new Point(p1, p2));
                    }

                    if (PointInsideTriangle(origin, triangle))
                    {
                        inside++;
                    }
                }
            }
            return inside.ToString();
        }
    }
}
