using Common;
using System;

namespace Problems.Problems100To149
{
    class Problem145 : IProblem

    {
        public int Number => 145;

        public string Execute()
        {
            var max = Math.Pow(10, 9);
            //max = 1000;
            int foundValues = 0;
            for (var i = 3; i < max; i += 2)
            {
                if (i % 10 == 0) continue;
                var reverse = Utility.ReverseNumber(i);
                if (IsFullyOdd(reverse + i))
                {
                    foundValues++;
                }
            }

            throw new ProblemIncompleteException();
            return foundValues.ToString();
        }

        public bool IsFullyOdd(long number)
        {
            if (number % 2 == 0) return false;
            while (number > 0)
            {
                var value = number;
                var digit = (value % 10) % 2;
                if (digit == 0) return false;
                number /= 10;
            }
            return true;
        }
    }
}
