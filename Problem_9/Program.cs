using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem_9
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = 1;
            var b = 2;
            var c = 3;

            while (true)
            {
             //   Debug.Print($"{a} {b} {c}");
                if (((a ^ 2) + (b ^ 2)) == (c ^ 2))
                {
                    if (a + b + c == 1000)
                    {
                        Debug.Print($"Winner {a} {b} {c}");
                        break;
                    }
                }

                if (a < b - 1)
                {
                    a++;
                }
                else
                {
                    a = 1;
                    if (b < c - 1)
                    {
                        b++;
                    }
                    else
                    {
                        b = 2;
                        c++;
                    }
                }


            }
        }
    }
}
