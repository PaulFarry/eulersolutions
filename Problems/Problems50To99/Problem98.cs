using Common;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Problems.Problems50To99
{

    class Problem098 : IProblem

    {
        public int Number => 98;

        public string Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p98.txt";
            var wordList = new List<string>();

            var data = string.Empty;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                while (true)
                {
                    var word = reader.ReadLine();
                    if (string.IsNullOrEmpty(word)) break;
                    wordList.Add(word);
                }
            }

            throw new ProblemIncompleteException("How on earth does 'CARE' become 1296");
        }
    }
}
