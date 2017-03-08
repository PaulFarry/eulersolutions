using System;
using System.Collections.Generic;
using System.Numerics;

namespace Common
{
    public class Utility
    {

        public static List<long> GetAllDivisors(long number)
        {
            var tippingPoint = Math.Sqrt(number);
            var divisors = new List<long> { 1 };
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

        public static long SumDigits(string number)
        {
            var digits = number.ToCharArray();
            var finalResult = 0;

            foreach (var digit in digits)
            {
                var digitValue = int.Parse(digit.ToString());
                finalResult += digitValue;
            }
            return finalResult;
        }

        public static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

    }
}
