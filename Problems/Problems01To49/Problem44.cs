using Common;
using System.Collections.Generic;

namespace Problems.Problems01To49
{
    class Problem44 : IProblem

    {
        public int Number => 44;

        //1, 5, 12, 22, 35, 51, 70, 92, 117, 145,
        public string Execute()
        {
            var maxValue = 2500;

            var pentagonals = new List<int>();

            for (var n = 1; n < maxValue; n++)
            {
                var p = (n * ((3 * n) - 1) / 2);
                pentagonals.Add(p);
            }

            var mg = int.MaxValue;

            var pentaLookup = new HashSet<int>(pentagonals);
            for (var j = 0; j < pentagonals.Count; j++)
            {
                for (var k = 0; k < pentagonals.Count; k++)
                {
                    if (j == k) continue;

                    var pk = pentagonals[k];
                    var pj = pentagonals[j];

                    var sum = pk + pj;

                    if (pentaLookup.Contains(sum))
                    {
                        var diff = pk - pj;
                        if (diff < 0) diff *= -1;
                        if (pentaLookup.Contains(diff))
                        {
                            if (diff < mg)
                            {
                                mg = diff;
                            }
                        }
                    }
                }
            }
            return mg.ToString();

        }
    }
}
