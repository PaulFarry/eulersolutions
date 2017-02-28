using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentValue = 1;
            var nextValue = 1;
            var totalItems = 0;
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

            Debug.Print(totalValue.ToString());

        }
    }
}
