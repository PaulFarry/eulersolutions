using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Problems100To149
{
    class Problem145 : IProblem

    {
        public int Number => 145;


        public string Execute()
        {
            var max = (int)Math.Pow(10, 9); //we can't have odd reversible with 9 digits
            var breakout = (int)Math.Pow(10, 8);
            //max = 1000; //Result = 120
            int foundValues = 0;

            var di = new Dictionary<int, int>();
            for (var i = 1; i <= 9; i++)
            {
                di.Add(i, 0);
            }

            for (var i = 1; i < max; i += 2)
            {
                if (i % 10 == 0) continue;
                var reverse = Utility.ReverseNumber(i);
                if (IsFullyOdd(reverse + i))
                {
                    foundValues += 2;
                    di[i.ToString().Length] += 2;
                }
                if (i >= 10000 && i <= 99999)
                {
                    i = 100000;
                    continue;
                }
                if (i >= breakout) break;
            }
            var r = di.Values.Sum();

            return (foundValues).ToString();
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

        /// <summary>
        /// After looking at the euler forums found this method of calculating the values from the analysis.
        /// </summary>
        /// <remarks>
        /// This comes from the maths site
        /// http://www.mathblog.dk/project-euler-145-how-many-reversible-numbers-are-there-below-one-billion/
        /// http://www.mathblog.dk/files/euler/Problem145.cs
        /// </remarks>
        public string Analytic()
        {
            var count = 0;

            for (var i = 1; i < 10; i++)
            {

                switch (i % 4)
                {
                    case 0:
                    case 2:
                        count += 20 * (int)Math.Pow(30, (i / 2 - 1));
                        break;
                    case 1:
                        count += 100 * (int)Math.Pow(500, i / 4 - 1);
                        break;
                    case 3:
                        break;
                }
            }
            return count.ToString();
        }
    }
}
