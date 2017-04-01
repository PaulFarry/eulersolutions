using System;
using System.Diagnostics;
using Common;

namespace Problems.Problems01To49
{
    public class Problem14 : IProblem
    {
        public int Number { get { return 14; } }

        public string Execute()
        {
            var fullTrace = false;

            var startPoint = 999999;
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
            return ($"{t.Item1} with Length of {t.Item2}");
        }
    }
}
