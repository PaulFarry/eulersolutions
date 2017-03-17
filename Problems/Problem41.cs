using Common;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problems
{
    class Problem41 : IProblem
    {
        public int Number => 41;

        public string Execute()
        {
            //largest pandigital prime.
            BigInteger start;
            BigInteger end;
            var primes = new List<BigInteger>();

            var characterCombinations = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            while (characterCombinations.Count >= 1)
            {
                var startString = string.Join("", characterCombinations);
                start = BigInteger.Parse(startString);
                var x = Utility.SumDigits(startString);
                if (x % 3 != 0)
                {
                    var revered = new List<char>(characterCombinations);
                    revered.Reverse();
                    end = BigInteger.Parse(string.Join("", revered));

                    for (BigInteger index = start; index <= end; index++)
                    {
                        if (index.IsPowerOfTwo) continue;
                        if (index.IsEven) continue;

                        var characters = new List<char>(index.ToString().ToCharArray());
                        var containsAll = true;
                        foreach (var c in characterCombinations)
                        {
                            if (!characters.Contains(c))
                            {
                                containsAll = false;
                                break;
                            }
                            else
                            {
                                characters.Remove(c);
                            }
                            if (!containsAll) break;
                        }
                        if (characters.Count > 0) continue;
                        if (!containsAll) continue;
                        if (Utility.IsPrime((long)index))
                        {
                            primes.Add(index);
                        }
                    }
                }
                characterCombinations.RemoveAt(characterCombinations.Count - 1);
            }
            primes.Sort();
            return primes.Last().ToString();
        }
    }
}
