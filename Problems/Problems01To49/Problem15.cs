using Common;
using System.Numerics;

namespace Problems.Problems01To49
{
    class Problem15 : IProblem
    {
        public int Number => 15;

        public string Execute()
        {
            //N Choose R
            var n = (BigInteger)20;

            BigInteger top = Utility.CalculateFactorial(2 * n);
            BigInteger bot = BigInteger.Pow(Utility.CalculateFactorial(n), 2);

            var result = top / bot;
            return result.ToString();
        }
    }
}
