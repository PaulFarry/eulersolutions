using Common;
using System.Collections.Generic;

namespace Problems.Problems01To49
{
    class Problem27 : IProblem
    {
        public int Number => 27;

        HashSet<long> primes;
        public string Execute()
        {
            primes = new HashSet<long>(Primes.GeneratePrimes(1, 20000));

            var highestYield = 0;
            var bestA = 0;
            var bestB = 0;


            var range = 1000;
            for (var a = -range; a < range; a++)
            {
                for (var b = -range; b <= range; b++)
                {
                    var total = CalculatePrimes(a, b);
                    if (total > highestYield)
                    {
                        bestA = a;
                        bestB = b;
                        highestYield = total;
                    }
                }
            }
            return (bestA * bestB).ToString();
        }

        private int CalculatePrimes(int a, int b)
        {
            var i = 0;
            while (true)
            {
                var n = (i * i) + (i * a) + b;
                if (n < 0 || !primes.Contains(n))
                {
                    return i;
                }

                i++;
            }
        }

    }
}
