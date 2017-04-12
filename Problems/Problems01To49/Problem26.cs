using Common;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problems.Problems01To49
{
    class Problem26 : IProblem
    {
        public int Number => 26;

        public string Execute()
        {
            var primes = Primes.LoadPrimes(1000);

            //return Attempt1(primes); //Mine
            //return Attempt2(primes); //Euler forums
            return Attempt3(primes); //Euler forums
        }

        private string Attempt3(List<long> primes)
        {
            var sequenceLength = 0;

            var longestIndex = 0;
            foreach (var p in primes)
            {
                if (p < 10) continue;
                var i = (int)p;
                if (sequenceLength >= i)
                {
                    break;
                }

                var foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while (foundRemainders[value] == 0 && value != 0)
                {
                    foundRemainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - foundRemainders[value] > sequenceLength)
                {
                    sequenceLength = position - foundRemainders[value];
                    longestIndex = i;
                }
            }
            return longestIndex.ToString();
        }
        private string Attempt1(List<long> primes)
        {
            var bigNumber = BigInteger.Pow(1000, 1000);
            var longest = 0;
            var longestValue = (long)0;
            foreach (var i in primes)
            {
                if (i <= 5) continue;
                var inverseResult = bigNumber / i;
                var inverse = inverseResult.ToString().TrimEnd('0');
                var offset = 0;
                while (offset < inverse.Length / 2)
                {
                    var p = FindPattern(inverse.Substring(offset));
                    if (p != null)
                    {
                        if (p.Length > longest)
                        {
                            longest = p.Length;
                            longestValue = i;
                            break;
                        }
                    }
                    offset++;
                }
            }
            return longestValue.ToString();
        }

        private string FindPattern(string text)
        {
            if (text == null)
            {
                return null;
            }

            return Enumerable
                .Range(1, text.Length / 2)
                .Where(n => text.Length % n == 0)
                .Select(n => text.Substring(0, n))
                .Where(pattern =>
                    Enumerable.Range(0, text.Length / pattern.Length)
                        .SelectMany(i => pattern)
                        .SequenceEqual(text)
                )
                .FirstOrDefault();
        }

        private string Attempt2(List<long> primes)
        {
            int n, len, maxlen, maxn = 0;
            maxlen = 0;
            foreach (var p in primes)
            {
                n = (int)p;
                int rest = 1;
                for (var i = 0; i < n; i++)
                {
                    rest = (rest * 10) % n;
                }
                var r0 = rest;
                len = 0;
                do
                {
                    rest = (rest * 10) % n;
                    len++;
                } while (rest != r0);
                if (len > maxlen)
                {
                    maxn = n;
                    maxlen = len;
                }
            }
            return maxn.ToString();
        }
    }
}
