using Common;
using System;
using System.Diagnostics;

namespace Problems.Problems01To49.Problems01To49
{
    public class Problem3 : IProblem
    {
        public int Number { get { return 3; } }

        public string Execute()
        {
            var originalValue = 600851475143;

            var s = (long)Math.Sqrt(originalValue);
            while(s >=2)
            {
                if (Utility.IsPrime(s))
                {
                    if (originalValue % s == 0)
                    {
                        return $"{s}";
                    }
                }
                s--;
            }
            return string.Empty;
        }

    }
}
