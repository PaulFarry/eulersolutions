using Common;
using System.IO;
using System.Reflection;

namespace Problems.Problems01To49.Problems50To99
{
    class Problem67 : IProblem
    {
        public int Number => 67;

        public string Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p67.txt";

            var data = string.Empty;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                data = reader.ReadToEnd();
            }

            var rows = Parsing.LoadSpaceSeparatedValueTree(data);

            return TreeSum.CalculateMaximumSum(rows);
        }
    }
}
