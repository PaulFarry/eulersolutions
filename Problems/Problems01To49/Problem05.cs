using Common;

namespace Problems.Problems01To49.Problems01To49
{
    public class Problem5 : IProblem
    {
        public int Number { get { return 5; } }

        public string Execute()
        {
            var calculatedValue = 1;
            while (true)
            {
                var divisor = 20;
                var isValid = true;
                while (isValid && divisor > 0)
                {
                    if (!(calculatedValue % divisor == 0))
                    {
                        isValid = false;
                    }
                    divisor--;
                }
                if (isValid)
                {
                    return $"{calculatedValue}";
                }
                calculatedValue++;
            }
        }
    }
}
