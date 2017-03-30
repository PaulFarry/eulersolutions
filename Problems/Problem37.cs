﻿using Common;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problems
{
    class Problem37 : IProblem
    {
        public int Number => 37;

        private HashSet<int> primeLookup;
        public string Execute()
        {
            var primes = Utility.LoadPrimes(1000000);

            var primeSum = 0;
            primeLookup = new HashSet<int>(primes);

            var primesFound = 0;

            foreach (var p in primes)
            {
                if (p <= 7) continue;

                if (TruncatablePrime(p))
                {
                    primeSum += p;
                    primesFound++;
                }
                if (primesFound == 11) break;
            }
            return primeSum.ToString();
        }

        private bool TruncatablePrime(int value)
        {
            var valueString = value.ToString();
            var valueLength = valueString.Length;

            for (var i = 1; i < valueLength; i++)
            {
                var leftValue = valueString.Substring(i);
                var leftNewValue = int.Parse(leftValue);
                if (!primeLookup.Contains(leftNewValue)) return false;

                var rightValue = valueString.Substring(0, valueLength - i);
                var rightNewValue = int.Parse(rightValue);
                if (!primeLookup.Contains(rightNewValue)) return false;
            }

            return true;
        }
    }
}