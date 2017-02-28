using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Common;

namespace Problem_7
{
    class Program
    {
        static void Main(string[] args)
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
            Debug.Print(primes.Last().ToString());

        }
    }
}
