using System;
using System.Collections.Generic;

namespace Common
{
    public class TreeSum
    {
        public static string CalculateMaximumSum(List<List<int>> rows)
        {
            var currentRowCounter = 0;
            rows.Reverse();

            for (var rowIndex = 0; rowIndex < rows.Count - 1; rowIndex++)
            {
                var row = rows[rowIndex];
                currentRowCounter++;
                List<int> currentRowBest = new List<int>();
                for (var valueIndex = 0; valueIndex < row.Count - 1; valueIndex++)
                {
                    var bestValue = Math.Max(row[valueIndex], row[valueIndex + 1]);
                    currentRowBest.Add(bestValue);
                }
                var sumRow = rows[currentRowCounter];
                for (var sumIndex = 0; sumIndex < sumRow.Count; sumIndex++)
                {
                    sumRow[sumIndex] += currentRowBest[sumIndex];
                }
            }
            rows.Reverse();

            return ((rows[0][0])).ToString();
        }
    }
}
