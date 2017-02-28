using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Common;

namespace Problem_10
{
    class Program
    {
        static void Main(string[] args)
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

            Debug.Print(total.ToString());

        }
    }
}
