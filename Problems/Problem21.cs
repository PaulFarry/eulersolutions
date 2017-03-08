﻿using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problems
{
    internal class Problem21 : IProblem
    {
        public int Number => 21;

        /*
    Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

    For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

    Evaluate the sum of all the amicable numbers under 10000.     */
        public string Execute()
        {
            var amicableNumbers = new List<int>();

            var startpoint = 4;

            for (var i = startpoint; i < 10000; i++)
            {
                if (!Utility.IsPrime(i))
                {
                    if (AmicableNumber(i))
                    {
                        amicableNumbers.Add(i);
                    }
                }
            }
            var result = amicableNumbers.Sum();

            amicableNumbers.ForEach(x => Debug.Print(x.ToString()));
            return result.ToString();
        }

        private List<int> GetDivisors(int number)
        {
            var tippingPoint = Math.Sqrt(number);
            var divisors = new List<int> { 1 };
            for (var i = 2; i <= tippingPoint; i++)
            {
                if ((number % i) == 0)
                {
                    divisors.Add(i);
                    divisors.Add(number / i);
                }
            }
            divisors.Sort();
            return divisors;
        }

        private bool AmicableNumber(int startNumber)
        {
            var original = GetDivisors(startNumber);
            var sumOriginalDivisors = original.Sum();
            var factor = GetDivisors(sumOriginalDivisors);
            var sumFactorDivisors = factor.Sum();
            if (sumOriginalDivisors == startNumber) return false;
            return ((sumFactorDivisors == startNumber));
        }
    }
}
