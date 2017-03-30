using Common;
using System.IO;
using System.Reflection;

namespace Problems
{
    class Problem67 : IProblem
    {
        public int Number => 67;

        public string Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = GetType().Namespace;

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
