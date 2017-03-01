using Common;
using System.Diagnostics;
using System.Numerics;

namespace Problems
{
    class Problem16 : IProblem
    {
        public int Number
        {
            get
            {
                return 16;
            }
        }

        public string Execute()
        {
            BigInteger startValue = 2;

            for(var i = 1;i<1000;i++)
            {
                startValue *= 2;
            }
            var value = Utility.SumDigits(startValue.ToString());
            return value.ToString();
        }
    }
}
