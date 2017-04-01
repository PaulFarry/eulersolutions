using Common;
using System;

namespace Problems.Problems01To49
{
    class Problem36 : IProblem

    {
        public int Number => 36;
        /*


The decimal number, 585 = 1001001001base2 (binary), is palindromic in both bases.

Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

(Please note that the palindromic number, in either base, may not include leading zeros.)

 *          */
        public string Execute()
        {
            var result = 0;

            for (var i = 1; i < 1000000; i++)
            {
                if (i % 10 == 0) continue;
                if (Utility.IsPalindrome(i) && (Utility.IsPalindrome(Convert.ToString(i, 2))))
                {
                    result += i;
                }
            }
            return result.ToString();
        }
    }
}
