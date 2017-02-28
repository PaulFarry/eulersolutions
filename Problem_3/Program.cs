using Common;
using System;
using System.Diagnostics;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var originalValue = 600851475143;

            var s = (long)Math.Sqrt(originalValue);
            while(s >=2)
            {
                if (Utility.IsPrime(s))
                {
                    if (originalValue % s == 0)
                    {
                        Debug.Print($"s = {s}");
                        break;
                    }
                }
                s--;
            }

        }

    }
}
