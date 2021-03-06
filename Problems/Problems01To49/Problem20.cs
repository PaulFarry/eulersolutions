﻿using Common;
using System.Numerics;

namespace Problems.Problems01To49
{
    public class Problem20 : IProblem
    {
        public int Number { get { return 20; } }

        public string Execute()
        {
            var startPoint = 100;
            BigInteger currentCalculation = 1;
            while (startPoint > 1)
            {
                currentCalculation = currentCalculation * (ulong)startPoint;
                startPoint--;
            }

            var value = Utility.SumDigits(currentCalculation);
                        
            return ($"{value}");
        }
    }
}
