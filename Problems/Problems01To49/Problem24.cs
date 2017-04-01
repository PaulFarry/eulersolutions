using Common;

namespace Problems.Problems01To49
{
    class Problem24 : IProblem
    {
        public int Number => 24;

        public string Execute()
        {
            var characterCombinations = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var g = Utility.GenerateCombinations(characterCombinations);
            return g[1000000 - 1];
        }
    }
}
