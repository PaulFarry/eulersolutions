using Common;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Problems
{
    class Problem1 : IProblem
    {
        public int Number { get { return 1; } }

        public string Execute()
        {
            var maxValue = 1000;
            var values = new List<int>();
            for (var i = 1; i < maxValue; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    values.Add(i);
                }
            }
            var total = values.Sum();
            return total.ToString();
        }
    }
}
