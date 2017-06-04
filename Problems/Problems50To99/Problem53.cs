using Common;
using System.Collections.Generic;
using System.Numerics;

namespace Problems.Problems50To99
{
    class Problem53 : IProblem
    {
        public int Number => 53;

        public string Execute()
        {
            factLookup = new Dictionary<int, BigInteger>();
            int foundItems = 0;

            for (var n = 1; n <= 100; n++)
            {
                var r = n;
                while (r > 0)
                {
                    var rFactorial = Factorial(r);
                    var nFactorial = Factorial(n);
                    var nrFactorial = Factorial(n - r);
                    var totalValues = nFactorial / (rFactorial * nrFactorial);


                    if (totalValues > 1000000)
                    {
                        //Debug.Print($"n = {n} r = {r} total = {totalValues}");
                        foundItems++;
                    }
                    r--;
                }
            }
            return foundItems.ToString();
        }

        private Dictionary<int, BigInteger> factLookup;
        private BigInteger Factorial(int value)
        {
            if (factLookup.ContainsKey(value))
            {
                return factLookup[value];
            }
            var sourceValue = (BigInteger)value;
            var result = Utility.CalculateFactorial(sourceValue);
            factLookup.Add(value, result);
            return result;
        }
    }
}
