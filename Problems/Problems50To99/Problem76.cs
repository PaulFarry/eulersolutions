using Common;
using System.Collections.Generic;

namespace Problems.Problems50To99
{
    class Problem76 : IProblem
    {
        public int Number => 76;

        //This is really the same as problem 31 with just more possible values to choose from.
        public string Execute()
        {
            var availableValues = new List<int>();
            {
                int TotalValue = 100;
                for (var c = TotalValue - 1; c > 0; c--)
                {
                    availableValues.Add(c);
                }


                int[,] ways = new int[availableValues.Count + 1, TotalValue + 1];
                ways[0, 0] = 1;
                for (var valueIndex = 0; valueIndex < availableValues.Count; valueIndex++)
                {
                    var value = availableValues[valueIndex];
                    for (var rowValue = 0; rowValue <= TotalValue; rowValue++)
                    {
                        var currentValue = value;
                        var nextValue = (rowValue >= currentValue ? ways[valueIndex + 1, rowValue - currentValue] : 0);
                        ways[valueIndex + 1, rowValue] = ways[valueIndex, rowValue] + nextValue;
                    }
                }
                return ways[availableValues.Count, TotalValue].ToString();
            }
        }
    }
}