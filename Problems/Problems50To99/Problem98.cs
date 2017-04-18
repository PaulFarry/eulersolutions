using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Problems.Problems50To99
{
    class Problem098 : IProblem
    {
        public int Number => 98;

        private class WordPair
        {
            public WordPair()
            {
                Words = new List<string>();
            }

            public void AddWord(string word)
            {
                Words.Add(word);
            }

            public List<string> Words { get; set; }
        }

        private Dictionary<string, WordPair> Pairs { get; set; }
        int totalLoops = 0;

        private Dictionary<string, WordPair> GetWords()
        {
            var wordPairs = new Dictionary<string, WordPair>();
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

                    var key = Utility.SortCharacters(word);
                    if (!wordPairs.TryGetValue(key, out var wp))
                    {
                        wp = new WordPair();
                        wordPairs.Add(key, wp);
                    }
                    wp.AddWord(word);
                }
            }
            return wordPairs;
        }


        private HashSet<long> squaresLookup;
        public string Execute()
        {

            Pairs = GetWords();

            var squareToValue = new Dictionary<int, long>();
            var squares = new HashSet<long>();
            var max = (int)Math.Pow(10, 9);

            var squaresLengths = new Dictionary<int, HashSet<long>>();
            squaresLookup = new HashSet<long>();

            for (var i = 1; ; i++)
            {
                var newValue = (long)Math.Pow(i, 2);
                squaresLookup.Add(newValue);

                if (newValue > max) break;

                var len = newValue.ToString().Length;
                if (!squaresLengths.TryGetValue(len, out var lookupSet))
                {
                    lookupSet = new HashSet<long>();
                    squaresLengths.Add(len, lookupSet);
                }

                lookupSet.Add(newValue);
                squareToValue.Add(i, newValue);
            }

            var totalMax = 0;

            foreach (var wp in Pairs.Where(x => x.Value.Words.Count == 2))
            {
                var pairLength = wp.Key.Length;
                var possibleSquares = squaresLengths[pairLength];

                totalMax = Math.Max(totalMax, ReplaceLettersToNumbers(possibleSquares, wp.Value));
            }
            return totalMax.ToString();
        }

        private int ReplaceLettersToNumbers(HashSet<long> possibleSquares, WordPair wordPair)
        {
            var maxValue = 0;

            foreach (var value in possibleSquares)
            {
                var calculationLookup = new Dictionary<char, char>();
                foreach (var key in wordPair.Words)
                {

                    var keys = key.ToCharArray();
                    var values = value.ToString().ToCharArray();

                    var kh = new HashSet<char>(keys);
                    var vh = new HashSet<char>(values);
                    if (kh.Count != vh.Count) continue;

                    for (var i = 0; i < keys.Length; i++)
                    {
                        var currentKey = keys[i];
                        var currentValue = values[i];
                        if (!calculationLookup.ContainsKey(currentKey))
                        {
                            calculationLookup.Add(currentKey, currentValue);
                        }
                    }
                    var tpr = TryPair(possibleSquares, calculationLookup, wordPair);

                    if (tpr > 0)
                    {
                        maxValue = Math.Max(maxValue, tpr);
                    }
                }
            }

            return maxValue;
        }

        private int TryPair(HashSet<long> possibleSquares, Dictionary<char, char> calculationLookup, WordPair wordPair)
        {
            var word1 = wordPair.Words[0];
            var word2 = wordPair.Words[1];

            var original1 = word1;
            var original2 = word2;

            foreach (var c in calculationLookup)
            {
                word1 = word1.Replace(c.Key, c.Value);
                word2 = word2.Replace(c.Key, c.Value);
            }

            if (int.TryParse(word1, out int value1) && int.TryParse(word2, out int value2))
            {
                if (word1.Length != value1.ToString().Length || word2.Length != value2.ToString().Length) return -1;

                if (possibleSquares.Contains(value1) && possibleSquares.Contains(value2))
                {
                    return Math.Max(value1, value2);
                }
            }
            return -1;
        }
    }
}
