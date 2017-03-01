using System.Collections.Generic;
using System.Linq;
using Common;

namespace Problems
{
    public class Problem7 : IProblem
    {
        public int Number { get { return 7; } }

        public string Execute()
        {
            var primes = new List<int>();
            var value = 1;
            while(primes.Count < 10001)
            {
                if (Utility.IsPrime(value))
                {
                    primes.Add(value);
                }
                value++;
            }
            return primes.Last().ToString();
        }
    }
}
