using Common;
using System.Collections.Generic;

namespace Problems.Problems01To49
{
    class Problem35 : IProblem
    {
        public int Number => 35;

        private HashSet<long> PrimeList = new HashSet<long>();

        public string Execute()
        {
            //circular primes < 100 = 2,3,5,7,11,13,17,31,37,71,73,79,97
            //circular primes < 1000000
            var maxValue = 1000000;
            var primes = Primes.LoadPrimes(maxValue);
            PrimeList = new HashSet<long>(primes);

            var circular = new HashSet<long>();

            foreach (var checkValue in PrimeList)
            {
                if (IsCircularPrime(checkValue))
                {
                    circular.Add(checkValue);
                }
            }

            return circular.Count.ToString();
        }

        private bool IsCircularPrime(long number)
        {
            if (number < 10)
            {
                return true;
            }

            var s = number.ToString();
            var split = s.ToCharArray();
            if (s.Contains("0")
             | s.Contains("2")
             | s.Contains("4")
             | s.Contains("5")
             | s.Contains("6")
             | s.Contains("8"))
                return false;

            for (var i = 0; i < s.Length; i++)
            {
                var checkCombo = s.Substring(i) + s.Substring(0, i);
                var checkValue = int.Parse(checkCombo);
                if (!PrimeList.Contains(checkValue))
                {
                    return false;
                }
            }
            return true;

        }
    }
}