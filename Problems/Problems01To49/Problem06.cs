using Common;

namespace Problems.Problems01To49.Problems01To49
{
    public class Problem6 : IProblem
    {
        public int Number { get { return 6; } }

        public string Execute()
        {
            var maxValue = 100;
            var squaredTotal = 0;

            var sumTotal = 0;

            for (var index = 1; index <= maxValue; index++)
            {
                sumTotal += index;
                squaredTotal += (index * index);
            }
            sumTotal *= sumTotal;

            var result = sumTotal - squaredTotal;
            return $"{result}";
        }
    }
}
