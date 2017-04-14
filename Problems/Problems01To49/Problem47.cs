using Common;
using System;
using System.Collections.Generic;

namespace Problems.Problems01To49
{
    class Problem47 : IProblem
    {
        public int Number => 47;

        List<long> primes;
        HashSet<long> primesLut;

        public string Execute()
        {
            primes = Primes.GeneratePrimes(1, 150000);
            primesLut = new HashSet<long>(primes);

            var sequenceCount = 4;

            for (var primeIndex = 0; primeIndex < primes.Count - 1; primeIndex++)
            {
                var nextPrime = primes[primeIndex + 1];

                var index = primes[primeIndex];
                while (index < nextPrime)
                {
                    var foundCount = 0;
                    for (var offset = 1; offset <= sequenceCount; offset++)
                    {
                        var value = index + offset;
                        if (!primesLut.Contains(value))
                        {
                            var factors = DistinctPrimeFactors(value);
                            if (factors.Count == sequenceCount)
                            {
                                foundCount++;
                                continue;
                            }
                            break;
                        }
                    }
                    index++;
                    if (foundCount == sequenceCount)
                    {
                        return index.ToString();
                    }
                }
            }
            return string.Empty;
        }

        private HashSet<long> DistinctPrimeFactors(long number)
        {
            var hs = new HashSet<long>();
            var upperBound = (long)Math.Sqrt(number);
            var index = 0;
            while (true)
            {
                var i = primes[index];
                if (i > upperBound) break;

                if (number % i == 0)
                {
                    do
                    {
                        var newValue = number / i;
                        number = newValue;
                    }
                    while (number % i == 0);
                    hs.Add(i);
                    upperBound = (long)Math.Sqrt(number);
                }
                index++;
            }

            if (number > 1)
            {
                hs.Add(number);
            }
            return hs;
        }
    }
}
