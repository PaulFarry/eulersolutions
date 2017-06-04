using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Problems50To99
{
    class Problem85 : IProblem
    {
        public int Number => 85;

        private int Combos(int m, int n)
        {
            //(m)(m+1)/2 (n)(n+1)/2 = m(m+1)(n)(n+1)/4
            //return ((m * (m + 1)) / 2) * ((n * (n + 1) / 2));
            return ((m * (m + 1) * n * (n + 1)) / 4);
        }

        public string Execute()
        {
            var target = 2000000;
            var bestDistance = target;
            var bestComobo = 0;

            var area = new Tuple<int, int>(0, 0);
            for (var m = 1; m < 1500; m++)
            {
                for (var n = 1; n < 1500; n++)
                {
                    var result = Combos(m, n);
                    var distance = Math.Abs(target - result);

                    if (distance < bestDistance)
                    {
                        bestDistance = distance;
                        bestComobo = result;
                        area = new Tuple<int, int>(m, n);
                    }

                }
            }
            // Debug.Print($"BEst = {bestComobo} Rectangle={area.Item1} * {area.Item2} Range = {bestDistance} ");
            return (area.Item2 * area.Item1).ToString();

        }
    }
}
