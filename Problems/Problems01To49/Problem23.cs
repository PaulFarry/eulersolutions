using Common;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Problems01To49
{
    class Problem23 : IProblem
    {
        public int Number => 23;

        HashSet<long> abundantValues;

        public string Execute()
        {
            var maximum = 28123;
            var primes = new HashSet<long>(Primes.GeneratePrimes(1, maximum));

            abundantValues = new HashSet<long>();

            for (var i = 1; i <= maximum; i++)
            {
                if (!primes.Contains(i))
                {
                    var div = Utility.GetDistinctDivisors(i);
                    var sum = div.Sum();
                    if (sum > i)
                    {
                        var abundant = i;
                        abundantValues.Add(i);
                    }
                }
            }

            var result = 0;
            for (var i = 1; i <= maximum; i++)
            {
                if (!SumAbundantLookup(i))
                {
                    result += i;
                }
            }

            return result.ToString();
        }

        private bool SumAbundantLookup(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (abundantValues.Contains(i) && abundantValues.Contains(number - i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
