using Common;
using System;
using System.Collections.Generic;

namespace Problems.Problems01To49
{
    class Problem46 : IProblem
    {

        public int Number => 46;

        public string Execute()
        {
            //sum of a prime and 2x a square
            //for every odd composite 

            var max = (int)Math.Pow(10, 4);
            var primes = Primes.GeneratePrimes(1, max);

            var primeLut = new HashSet<long>(primes);


            var squares = new HashSet<long>();
            for (var s = 1; s <= max; s++)
            {
                squares.Add(2 * (int)Math.Pow(s, 2));
            }

            for (var i = 3; i <= max; i += 2)
            {
                if (primeLut.Contains(i)) continue;
                var found = false;
                foreach (var p in primes)
                {
                    if (p >= i) break;
                    var diff = i - p;

                    if (diff > 0 && squares.Contains(diff))
                    {
                        var sq = Math.Sqrt(diff / 2);
                        // Debug.Print($"{i} = {p} + 2*({sq}^2)");

                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    return i.ToString();
                }
            }
            return string.Empty;
        }
    }
}
