using Common;
using System;
using System.Numerics;

namespace Problems.Problems01To49.Problems50To99
{
    class Problem56 : IProblem
    {
        public int Number => 56;

        public string Execute()
        {
            long currentMax = 0;

            for (BigInteger a = 1; a < 100; a++)
            {
                for (int b = 1; b < 100; b++)
                {
                    var result = BigInteger.Pow(a, b);
                    var subSum = Utility.SumDigits(result);
                    currentMax = Math.Max(subSum, currentMax);
                }
            }
            return currentMax.ToString();
        }
    }
}
