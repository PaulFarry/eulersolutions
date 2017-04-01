using Common;

namespace Problems.Problems01To49.Problems01To49
{
    public class Problem2 : IProblem
    {
        public int Number { get { return 2; } }

        public string Execute()
        {
            var currentValue = 1;
            var nextValue = 1;
            var totalValue = (long)0;

            while (true)
            {
                if (nextValue < 4000000)
                {
                    if (nextValue % 2 == 0)
                    {
                        totalValue += nextValue;
                    }
                }
                else
                {
                    break;
                }
                /*
                if (totalItems++ < 10)
                {
                    Debug.Print(nextValue.ToString());
                }
                else
                {
                    break;
                }
                */

                int temp = currentValue;
                currentValue = nextValue;
                nextValue = temp + currentValue;

            }

            return totalValue.ToString();
        }
    }
}
