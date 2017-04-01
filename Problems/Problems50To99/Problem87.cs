using Common;
using System;
using System.Collections.Generic;

namespace Problems.Problems01To49.Problems50To99
{
    class Problem87 : IProblem
    {
        public int Number => 87;

        public string Execute()
        {
            var primes = Utility.LoadPrimes(7200);
            var maxCap = 50000000;

            var numbers = new HashSet<int>();

            for (var squareIndex = 0; squareIndex < primes.Count; squareIndex++)
            {
                var square = (int)Math.Pow(primes[squareIndex], 2);
                for (var cubeIndex = 0; cubeIndex < primes.Count; cubeIndex++)
                {
                    var cube = (int)Math.Pow(primes[cubeIndex], 3);
                    for (var quadIndex = 0; quadIndex < primes.Count; quadIndex++)
                    {
                        var quad = (int)Math.Pow(primes[quadIndex], 4);
                        if (quad > maxCap) break;

                        var ts = square + cube + quad;
                        if (ts > maxCap) break;
                        numbers.Add(ts);
                    }
                    if (cube > maxCap) break;
                }
                if (square > maxCap) break;
            }
            return numbers.Count.ToString();
        }
    }
}
