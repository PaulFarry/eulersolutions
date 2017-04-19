using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Common
{
    public class Utility
    {
        private static string Pandigital9Compare = "123456789";

        public static bool Pandigital(StringBuilder value)
        {
            if (value.Length != 9) return false;
            return Pandigital(value.ToString());
        }

        public static bool Pandigital(string value)
        {
            if (value.Length != 9) return false;
            var arr = value.ToCharArray();
            Array.Sort(arr);
            var joined = string.Join("", arr);
            if (Pandigital9Compare == joined)
            {
                return true;
            }
            return false;
        }

        static BigInteger GCD(BigInteger[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static BigInteger LCM(BigInteger[] numbers)
        {
            return numbers.Aggregate(LCM);
        }

        static BigInteger GCD(BigInteger a, BigInteger b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static BigInteger LCM(BigInteger a, BigInteger b)
        {
            BigInteger num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (BigInteger i = 1; i < num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num1 * num2;
        }

        public static int GreatestCommonDenominator(int numerator, int denominator)
        {
            var cap = numerator > denominator ? numerator : denominator;
            for (var i = cap; i >= 2; i--)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    return i;
                }
            }
            return 1;

        }
        public static int CalculateFactorial(int value)
        {
            if (value == 1) return 1;
            int res = 1;
            for (int i = 2; i <= value; i++)
            {
                res *= i;
            }
            return res;
        }

        public static string SortCharacters(string text)
        {
            var characters = text.ToArray();
            Array.Sort(characters);
            return string.Join("", characters);
        }

        public static long ReverseNumber(long number)
        {
            var characters = number.ToString().ToCharArray();
            Array.Reverse(characters);
            var value = string.Join("", characters);
            return long.Parse(value);
        }



        public static bool ContainsAllDigitsSort(int currentIndex, int comparision)
        {
            var current = new List<char>(currentIndex.ToString().ToCharArray());
            var compare = new List<char>(comparision.ToString().ToCharArray());
            current.Sort();
            compare.Sort();
            return (string.Join("", current) == string.Join("", compare));
        }
        public static bool ContainsAllDigits(int currentIndex, int comparision)
        {
            var current = new List<char>(currentIndex.ToString().ToCharArray());
            var compare = new List<char>(comparision.ToString().ToCharArray());

            foreach (var c in current)
            {
                var position = compare.IndexOf(c);
                if (position < 0) return false;
                compare.RemoveAt(position);
            }

            return true;
        }

        public static BigInteger CalculateFactorial(BigInteger value)
        {
            if (value == 1) return 1;
            BigInteger result = 1;
            for (int i = 2; i <= value; i++)
            {
                result *= i;
            }
            return result;

        }


        public static HashSet<int> CalculateTriangleNumbers(int largestValue)
        {
            var result = new HashSet<int>();

            var n = 1;

            while (true)
            {
                int t = n * (n + 1) / 2;
                n++;
                result.Add(t);
                if (t > largestValue) break;
            }
            return result;
        }


        public static List<long> GetDistinctDivisors(long number)
        {
            var divisors = new HashSet<long>() { 1 };
            var tippingPoint = Math.Sqrt(number);
            for (var i = 2; i <= tippingPoint; i++)
            {
                if ((number % i) == 0)
                {
                    divisors.Add(i);
                    divisors.Add(number / i);
                }
            }
            return divisors.ToList();
        }

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

        /*
         * Psuedocode from Wikipedia
        procedure generate(n : integer, A : array of any):
            c : array of int

            for i := 0; i < n; i += 1 do
                c[i] := 0
            end for

            output(A)

            i := 0;
            while i < n do
                if  c[i] < i then
                    if i is even then
                        swap(A[0], A[i])
                    else
                        swap(A[c[i]], A[i])
                    end if
                    output(A)
                    c[i] += 1
                    i := 0
                else
                    c[i] := 0
                    i += 1
                end if
            end while
         */

        public static List<string> GenerateCombinations(string word)
        {
            return GenerateCombinations(word.ToCharArray());
        }

        public static List<string> GenerateCombinations(char[] characters)
        {
            var result = new List<string>();

            var offsetArray = new int[characters.Length];
            var totalLength = characters.Length;

            for (var index = 0; index < totalLength; index++)
            {
                offsetArray[index] = 0;
            }

            var outputValue = new string(characters);
            result.Add(outputValue);


            var i = 0;
            while (i < totalLength)
            {
                if (offsetArray[i] < i)
                {
                    if ((i % 2) == 0)
                    {
                        var tmp = characters[0];
                        characters[0] = characters[i];
                        characters[i] = tmp;
                    }
                    else
                    {
                        var tmp = characters[offsetArray[i]];
                        characters[offsetArray[i]] = characters[i];
                        characters[i] = tmp;
                    }

                    outputValue = new string(characters);
                    result.Add(outputValue);
                    offsetArray[i] += 1;
                    i = 0;
                }
                else
                {
                    offsetArray[i] = 0;
                    i += 1;
                }
            }
            result.Sort();
            return result;
        }


        public static long SumDigits(BigInteger number)
        {
            return SumDigits(number.ToString());
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

        public static bool IsPalindrome(int value)
        {
            return IsPalindrome(value.ToString());
        }

        public static bool IsPalindrome(string value)
        {
            var left = string.Empty;
            var right = string.Empty;
            var length = value.Length / 2;
            //if (value.Length % 2 != 0) length--;
            left = value.Substring(0, length);
            right = string.Join("", value.Substring(value.Length - length).ToCharArray().Reverse());
            return left == right;
        }

    }
}
