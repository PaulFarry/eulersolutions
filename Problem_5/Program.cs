using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculatedValue = 1;
            while (true)
            {
                var divisor = 20;
                var isValid = true;
                while (isValid && divisor > 0)
                {
                    if (!(calculatedValue % divisor == 0))
                    {
                        isValid = false;
                    }
                    divisor--;
                }
                if (isValid)
                {
                    Debug.Print($"Calculated = {calculatedValue}");
                    break;
                }
                calculatedValue++;
            }
        }
    }
}
