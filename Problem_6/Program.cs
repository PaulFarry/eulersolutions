using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem_6
{
    class Program
    {
        static void Main(string[] args)
        {

            var maxValue = 100;
            var squaredTotal = 0;

            var sumTotal = 0;

            for (var index = 1; index <= maxValue; index++)
            {
                sumTotal += index;
                squaredTotal += (index * index);
            }
            sumTotal *= sumTotal;

            var result = sumTotal - squaredTotal;
            Debug.Print($"Result {result}");

        }
    }
}
