using Common;
using System;
using System.Text;

namespace Problems.Problems01To49
{
    class Problem38 : IProblem
    {
        public int Number => 38;

        public string Execute()
        {
            var joiner = new StringBuilder();
            int maxPandigital = int.MinValue;

            for (int n = 2; n <= 9; n++)
            {
                var maxI = (int)Math.Pow(10, 9 / n);
                var minI = Math.Sqrt(maxI);

                for (int i = maxI - 1; i >= minI; i--)
                {
                    joiner.Clear();
                    for (var multiplier = 1; multiplier <= n; multiplier++)
                    {
                        joiner.Append(i * multiplier);
                        if (joiner.Length > 9) break;
                        if (joiner.Length == 9 && Utility.Pandigital(joiner))
                        {
                            var pMax = int.Parse(joiner.ToString());
                            if (pMax > maxPandigital)
                            {
                                maxPandigital = pMax;
                            }
                        }

                    }
                }
            }
            return maxPandigital.ToString();
        }
    }
}
