using Common;
using System.Numerics;

namespace Problems.Problems50To99
{
    class Problem97 : IProblem

    {
        public int Number => 97;

        public string Execute()
        {
            //(28433×2^7830457)+1.

            var m = (BigInteger)28433;
            var fact = BigInteger.Pow(2, 7830457);
            var largePrime = (m * fact) + 1;

            BigInteger mod = 10000000000;

            var last10 = largePrime % mod;

            return last10.ToString();
        }
    }
}
