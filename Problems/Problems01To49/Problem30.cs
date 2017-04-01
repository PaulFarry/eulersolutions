using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Problems01To49
{
    class Problem30 : IProblem
    {
        public int Number => 30;

        public string Execute()
        {
            var power = 5;
            var start = 2;
            var end = (power + 1) * Math.Pow(9, power);

            var values = new List<int>();

            for (var value = start; value <= end; value++)
            {
                if (PowerDigits(value, power))
                {
                    values.Add(value);
                }
            }
            return values.Sum().ToString();
        }

        private bool PowerDigits(int value, int power)
        {
            var sum = 0;
            foreach (var digit in value.ToString().ToCharArray())
            {
                var dVal = int.Parse(digit.ToString());
                var digPowe = (int)Math.Pow(dVal, power);
                sum += digPowe;
            }

            if (sum == value) return true;
            return false;
        }
    }
}
