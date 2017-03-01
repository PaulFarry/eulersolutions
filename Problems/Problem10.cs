using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Common;

namespace Problems
{
    public class Problem10 : IProblem
    {
        public int Number { get { return 10; } }

        public string Execute()
        {
            var value = 1;
            long total = 0;
            while (value < 2000000)
            {
                if (Utility.IsPrime(value))
                {
                    total += value;
                }
                value++;
            }

            return total.ToString();
        }

    }
}
