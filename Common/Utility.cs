using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Common
{
    public class Utility
    {
        public static void GeneratePrimes(long minValue, long maxValue)
        {
            {
                var items = new StringBuilder();
                for (var i = 1; i < maxValue; i++)
                {
                    if (IsPrime(i))
                    {
                        items.AppendLine($"{i}");
                    }
                }
                Debug.Print(items.ToString());
            }
        }

        public static void GeneratePrimes(long maximumValue)
        {
            GeneratePrimes(1, maximumValue);
        }

        public static List<int> LoadPrimes()
        {
            return LoadPrimes(int.MaxValue);
        }

        public static List<int> LoadPrimes(int maximumValue)
        {
            var values = new List<int>();
            using (var primeResourceFileData = Assembly.GetExecutingAssembly().GetManifestResourceStream("Common.PrimeList.txt"))
            {
                using (var sr = new StreamReader(primeResourceFileData))
                {
                    while (true)
                    {
                        var currentLine = sr.ReadLine();
                        if (string.IsNullOrEmpty(currentLine)) break;
                        var currentValue = int.Parse(currentLine);
                        if (currentValue <= maximumValue)
                        {
                            values.Add(currentValue);
                        }
                    }
                }
            }
            return values;
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
