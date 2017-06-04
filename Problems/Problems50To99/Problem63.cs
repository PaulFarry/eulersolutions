using Common;
using System.Numerics;

namespace Problems.Problems50To99
{
    class Problem63 : IProblem
    {
        public int Number => 63;

        public string Execute()
        {
            /*
The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power.

How many n-digit positive integers exist which are also an nth power?
*/
            var bigValue = (BigInteger)1;
            var counter = 0;
            for (var i = 1; i < 22; i++)
            {
                for (var x = 1; x <= 9; x++)
                {
                    bigValue = BigInteger.Pow(x, i);
                    if (bigValue.ToString().Length == i)
                    {
                        counter++;
                    }
                }
            }
            return counter.ToString();
        }
    }
}
