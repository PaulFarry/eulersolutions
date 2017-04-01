using Common;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problems.Problems01To49
{
    class Problem31 : IProblem
    {
        public int Number => 31;

        [DebuggerDisplay("{Name} + {Value}")]
        private class Currency
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public string Execute()
        {
            var Coins = new List<Currency> {
            new Currency {Name = "1p", Value = 1 },
            new Currency {Name = "2p", Value = 2 },
            new Currency {Name ="5p", Value = 5 },
            new Currency {Name= "10p", Value = 10 },
            new Currency {Name = "20p", Value = 20 },
            new Currency {Name = "50p", Value = 50 },
            new Currency {Name = "100p", Value = 100 },
            new Currency {Name= "200p", Value= 200 }
             };

            //find all combinations of coins that add up to 2pound (200p)
            int TotalValue = 200;

            int[,] ways = new int[Coins.Count + 1, TotalValue + 1];
            ways[0, 0] = 1;
            for (var coinIndex = 0; coinIndex < Coins.Count; coinIndex++)
            {
                var coin = Coins[coinIndex];
                for (var rowValue = 0; rowValue <= TotalValue; rowValue++)
                {
                    var coinValue = coin.Value;
                    var nextValue = (rowValue >= coinValue ? ways[coinIndex + 1, rowValue - coinValue] : 0);
                    ways[coinIndex + 1, rowValue] = ways[coinIndex, rowValue] + nextValue;
                }
            }
            return ways[Coins.Count, TotalValue].ToString();
        }
    }
}
