using Common;

namespace Problems.Problems50To99
{
    class Problem52 : IProblem
    {
        public int Number => 52;

        private bool Calculate(int value, int multiplier)
        {
            return Utility.ContainsAllDigits(value, value * multiplier);
        }
        public string Execute()
        {
            var currentIndex = 100000;
            while (true)
            {
                currentIndex++;
                if (Calculate(currentIndex, 2) &&
                    Calculate(currentIndex, 3) &&
                    Calculate(currentIndex, 4) &&
                    Calculate(currentIndex, 5) &&
                    Calculate(currentIndex, 6))
                {
                    return currentIndex.ToString();
                }
            }
        }
    }
}
