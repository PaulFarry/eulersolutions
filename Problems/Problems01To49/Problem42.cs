using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Problems.Problems01To49
{
    class Problem42 : IProblem
    {
        public int Number => 42;

        public string Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p42.txt";

            var data = string.Empty;
            var namesList = new Dictionary<string, int>();

            var largestValue = 0;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (true)
                {
                    var currentLine = reader.ReadLine();
                    if (string.IsNullOrEmpty(currentLine)) break;
                    int rowSum = currentLine.Sum(c => c - 64);
                    namesList.Add(currentLine, rowSum);
                    largestValue = Math.Max(rowSum, largestValue);
                }
            }
            var tria = Utility.CalculateTriangleNumbers(largestValue);

            var wordsFound = 0;
            foreach(var kvp in namesList)
            {
                if (tria.Contains(kvp.Value)) wordsFound++;
            }
            return wordsFound.ToString();
        }

    }
}
