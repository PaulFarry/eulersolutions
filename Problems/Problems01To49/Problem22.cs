using Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Problems.Problems01To49
{
    class Problem22 : IProblem
    {
        public int Number => 22;

        public string Execute()
        {
            List<string> names = LoadNameList();
            names.Sort();

            long totalScore = 0;

            for (var nameIndex = 0; nameIndex < names.Count; nameIndex++)
            {
                int rowSum = names[nameIndex].Sum(c => c - 64);
                var rowScore = rowSum * (nameIndex + 1);
                totalScore += rowScore;
            }

            return totalScore.ToString();
        }

        private List<string> LoadNameList()
        {
            var names = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p022_names.txt";
            var data = string.Empty;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                data = reader.ReadToEnd().Trim();
            }
            names = new List<string>(data.Split(','));
            for (var nameIndex = 0; nameIndex < names.Count; nameIndex++)
            {
                names[nameIndex] = names[nameIndex].Trim('"').Trim();
            }
            return names;
        }
    }
}
