using Common;
using System;

namespace Problems.Problems01To49
{
    class Problem39 : IProblem
    {
        public int Number => 39;

        public string Execute()
        {
            // perimeter = a+b+c;
            //c = sqrt(a^2 + b^2)
            /*
            If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

            {20,48,52}, {24,45,51}, {30,40,50}

            For which value of p ≤ 1000, is the number of solutions maximised?
            */

            var maxValue = 0;
            var currentMax = 0;

            for (var p = 1; p <= 1000; p++)
            {
                var total = 0;
                for (var a = 3; a <= p / 2; a++)
                {
                    var a2 = Math.Pow(a, 2);

                    for (var b = 4; b <= p - a; b++)
                    {
                        var b2 = Math.Pow(b, 2);

                        var h = Math.Sqrt(a2 + b2);
                        if ((a + b + h) == p)
                        {
                            total++;
                        }
                    }
                }
                if (total > currentMax)
                {
                    maxValue = p;
                    currentMax = total;
                }
            }

            return maxValue.ToString();
        }
    }
}
