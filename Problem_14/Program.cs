using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullTrace = false;

            var startPoint = 999999;
            //startPoint = 270271;
            var t = new Tuple<int, int>(0, 0);

            while (true)
            {
                var currentPoint = (long)startPoint;
                var length = 0;
                while (true)
                {
                    if (currentPoint == 1)
                    {
                        if (length > t.Item2)
                        {
                            t = new Tuple<int, int>(startPoint, length);
                        }
                        if (fullTrace) Debug.Print($"Chain for {startPoint} = {length}");
                        break;
                    }


                    length++;

                    if (currentPoint % 2 == 0)
                    {
                        currentPoint = currentPoint / 2;
                    }
                    else
                    {
                        currentPoint = (currentPoint * 3) + 1;
                    }
                    if (fullTrace) Debug.Print($"Current point = {currentPoint}");

                }
                startPoint--;
                  if (startPoint <= 1) break;
            }
            Debug.Print($"Longest = {t.Item1} with Length of {t.Item2}");
        }
    }
}
