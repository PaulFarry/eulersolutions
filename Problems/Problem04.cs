using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class Problem4 : IProblem
    {
        public int Number { get { return 4; } }

        public string Execute()
        {
            var list = new List<long>();

            for (var leftSide = 100; leftSide < 1000; leftSide++)
            {
                for (var rightSide = 100; rightSide < 1000; rightSide++)
                {
                    var result = leftSide * rightSide;
                    if (IsPalindrome(result))
                    {
                        list.Add(result);
                    }
                }
            }
            list.Sort();
            var largest = list.Last();
            return largest.ToString();
        }

        static bool IsPalindrome(long value)
        {
            var calculated = value.ToString();
            var length = calculated.Length;
            var partToGrab = (int)Math.Floor(length / 2.0);
            var start = calculated.Substring(0, partToGrab);
            var tail = calculated.Substring(length - partToGrab, partToGrab);
            var reversedStart = new string(start.ToCharArray().Reverse().ToArray());
            return (tail == reversedStart);
        }
    }
}
