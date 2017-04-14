using Common;
using System.Numerics;

namespace Problems.Problems01To49
{
    class Problem48 : IProblem

    {
        public int Number => 48;

        public string Execute()
        {
            BigInteger result = 0;

            for (var i = 1; i <= 1000; i++)
            {
                var b = BigInteger.Pow(i, i);
                result += b;
            }

            var total = result.ToString();
            var last10 = total.Substring(total.Length - 10);

            return last10;
        }
    }
}
