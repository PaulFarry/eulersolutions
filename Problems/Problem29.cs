using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problems
{
    class Problem29 : IProblem
    {
        public int Number => 29;

        public string Execute()
        {
            var upperLimit = 100;
            var hashSet = new HashSet<BigInteger>();
            for (long a = 2; a <= upperLimit; a++)
            {
                for (long b = 2; b <= upperLimit; b++)
                {
                    var value = (BigInteger)Math.Pow(a, b);
                    hashSet.Add(value);
                }
            }

            return hashSet.Count().ToString();
        }
    }
}
