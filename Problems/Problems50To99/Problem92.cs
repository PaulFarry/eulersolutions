using Common;
using System;
using System.Collections.Generic;

namespace Problems.Problems50To99
{
    class Problem92 : IProblem
    {
        public int Number => 92;

        private HashSet<int> SolvedValues;
        private HashSet<int> Bucket89;

        public string Execute()
        {

            var max = (int)Math.Pow(10, 7);
            var totalValues = 0;

            Bucket89 = new HashSet<int>();
            SolvedValues = new HashSet<int>();

            var chains = new Dictionary<int, HashSet<int>>();
            var subMax = SumSquareDigits(max - 1);  // Find out maximum starting reduced start point.

            for (var startPoint = 1; startPoint < subMax; startPoint++)
            {
                totalValues = CalculateChain(totalValues, startPoint);
            }

            for (var startPoint = subMax; startPoint < max; startPoint++)
            {
                totalValues = CalculateChain(totalValues, startPoint);
            }


            return totalValues.ToString();
        }

        private int CalculateChain(int totalValues, int startPoint)
        {
            var chainValue = startPoint;
            var chain = new List<int>();
            while (true)
            {
                var newChainValue = SumSquareDigits(chainValue);

                if (SolvedValues.Contains(newChainValue))
                {
                    if (Bucket89.Contains(newChainValue))
                    {
                        totalValues++;
                    }
                    break;
                }
                else
                {
                    if (chain.Contains(newChainValue) && (newChainValue == 1 || newChainValue == 89))
                    {
                        chain.Add(newChainValue);

                        if (newChainValue == 89)
                        {
                            totalValues++;
                            foreach (var value in chain)
                            {
                                if (value > 10)
                                {
                                    var reverse = value.ToString().ToCharArray();
                                    Array.Reverse(reverse);

                                    var altValue = int.Parse(string.Join("", reverse));
                                    Bucket89.Add(altValue);

                                }
                                Bucket89.Add(value);
                            }
                        }

                        foreach (var value in chain)
                        {
                            SolvedValues.Add(value);
                        }
                        break;
                    }
                    chain.Add(newChainValue);
                    chainValue = newChainValue;
                }
            }

            return totalValues;
        }

        private Dictionary<int, int> squaresLut;

        private int SumSquareDigits(int value)
        {
            if (squaresLut == null)
            {
                squaresLut = new Dictionary<int, int>();

                for (var i = 0; i < 10; i++)
                {
                    var square = (int)Math.Pow(i, 2);
                    var ch = i.ToString().ToCharArray()[0];
                    squaresLut.Add(i, square);
                }
            }

            var sum = 0;
            while (value > 0)
            {
                var d = value % 10;
                value /= 10;
                sum += squaresLut[d];
            }
            return sum;
        }
    }
}
