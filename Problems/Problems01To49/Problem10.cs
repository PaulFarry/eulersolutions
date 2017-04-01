using Common;

namespace Problems.Problems01To49.Problems01To49
{
    public class Problem10 : IProblem
    {
        public int Number { get { return 10; } }

        public string Execute()
        {
            long total = 0;
            var primeList = Utility.LoadPrimes(2000000);
            foreach(var value in primeList)
            {
                total += value;
            }

            return total.ToString();
        }

    }
}
