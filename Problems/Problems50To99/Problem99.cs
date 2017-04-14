using Common;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace Problems.Problems50To99
{
    class Problem99 : IProblem
    {
        public int Number => 99;

        public string Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p99.txt";

            var data = string.Empty;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                data = reader.ReadToEnd();
            }

            var lineNumber = 0;
            var maxValue = 0d;
            var maxLineNumber = 0;
            using (var s = new StringReader(data))
            {
                while (true)
                {
                    var line1 = s.ReadLine();
                    if (!string.IsNullOrEmpty(line1))
                    {
                        lineNumber++;
                        var lineSplit = line1.Split(',');
                        var factor = int.Parse(lineSplit[0]);
                        var power = int.Parse(lineSplit[1]);

                        var value1 = (BigInteger.Log(factor) * power);
                        if (value1 > maxValue)
                        {
                            maxValue = value1;
                            maxLineNumber = lineNumber;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return maxLineNumber.ToString();
        }
    }
}