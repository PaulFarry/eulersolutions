using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Problems50To99
{
    class Problem92 : IProblem
    {
        public int Number => 92;

        public string Execute()
        {
            var max = (int)Math.Pow(10, 7);
            var totalValues = 0;

            var sb = new StringBuilder();
            //var startPoint = 44;
            var chains = new Dictionary<int, HashSet<int>>();
            for (var startPoint = 1; startPoint < max; startPoint++)
            //   var startPoint = 85;
            {
            
                var chainValue = startPoint;
                if (chainValue == 89) continue;
                var chain = new HashSet<int>();
                //sb.Clear();
                while (true)
                {
                    var newChainValue = SumSquareDigits(chainValue);
                    //if (chains.Contains(newChainValue))
                    {
                        //  chain = chains[newChainValue];
                    }
                    if (chain.Contains(newChainValue))
                    {
                        chain.Add(newChainValue);

                        if (newChainValue == 89)
                        {
                            totalValues++;
                            //     Debug.Print($"{startPoint} = {chain.Count}");
                        }
                        /*
                        sb.Append(startPoint);
                        foreach (var v in chain)
                        {
                            sb.Append(" > ");
                            sb.Append(v);
                        }
                        sb.Append(" > ").Append(newChainValue);
                        Debug.Print(sb.ToString());
                        */
                        break;
                    }
                    chain.Add(newChainValue);
                    chainValue = newChainValue;
                }
            }
            return totalValues.ToString(); ;
        }

        private int SumSquareDigits(int startPoint)
        {
            var sum = 0;
            foreach (var c in startPoint.ToString().ToCharArray())
            {
                sum += (int)Math.Pow(int.Parse(c.ToString()), 2);
            }
            return sum;
        }
    }
}
