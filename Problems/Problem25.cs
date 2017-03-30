using Common;
using System.Collections.Generic;
using System.Numerics;

namespace Problems
{
    class Problem25 : IProblem
    {
        public int Number => 25;
        //Find the index of the 1st Fibonacci number to contain 1000 digits.


        public string Execute()
        {
            var b = new BigInteger(1);
            var next = new BigInteger(1);
            var items = new List<BigInteger>
            {
                b,
                b
            };
            while (true)
            {
                var c = b + next;
                b = next;
                next = c;
                items.Add(c);
                if (c.ToString().Length == 1000)
                {
                    var resultItem = c;
                    return items.Count.ToString();
                }
            }
        }
    }
}
