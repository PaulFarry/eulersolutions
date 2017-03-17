using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class Problem31 : IProblem
    {
        public int Number => 31;

        private class Currency
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public string Execute()
        {
            var values = new List<Currency> {
            new Currency { Name = "1p", Value = 1 },
            new Currency {Name = "2p" , Value = 2 },
            new Currency { Name ="5p", Value = 5 },
            new Currency { Name= "10p", Value = 10 },
            new Currency {Name = "20p" , Value = 20 },
            new Currency {Name = "50p" , Value = 50 },
            new Currency {Name = "100p" , Value = 100 },
             };
            //1p 
            //2p
            //5p
            //10p
            //20p
            //50p
            //1Pound = 100p
            //find all combinations of coins that add up to 2pound (200p)
            throw new ProblemIncompleteException();
        }
    }
}
