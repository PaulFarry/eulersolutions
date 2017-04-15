using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Problems01To49
{
    class Problem32 : IProblem
    {
        public int Number => 32;

        public string Execute()
        {

            var compareString = "123456789";
            var results = new HashSet<int>();

            var maxRange = 10000;

            for (var a = 1; a < 2000; a++)
            {
                for (var b = 1; b < 1750; b++)
                {
                    var result = a * b;
                    if (result > maxRange) continue;

                    var test = string.Concat(result, b, a);
                    if (test.Length != 9) continue;
                    var chars = test.ToCharArray();
                    Array.Sort(chars);
                    var resultString = string.Join("", chars);
                    if (resultString == compareString)
                    {
                        results.Add(result);
                    }
                }
            }

            var finalResult = results.Sum();
            return finalResult.ToString();
        }
    }
}
