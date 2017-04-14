using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Problems01To49
{
    class Problem49 : IProblem
    {
        public int Number => 49;

        public string Execute()
        {
            var pl = Primes.GeneratePrimes(1000, 10000);
            var lut = new HashSet<string>();
            var itemsList = new Dictionary<string, List<int>>();

            foreach (var p in pl)
            {
                var cl = new List<char>(p.ToString().ToCharArray());
                cl.Sort();
                var ss = string.Join("", cl);
                if (!lut.Contains(ss))
                {
                    lut.Add(ss);
                    var items = new List<int> { (int)p };
                    itemsList.Add(ss, items);
                }
                else
                {
                    var items = itemsList[ss];
                    items.Add((int)p);
                }
            }

            foreach (var i in itemsList)
            {
                var valueList = i.Value;
                if (valueList.Count >= 3)
                {
                    for (var a = 0; a < valueList.Count; a++)
                    {
                        var valuea = valueList[a];

                        for (var b = a + 1; b < valueList.Count; b++)
                        {
                            var valueb = valueList[b];
                            var diff = valueb - valuea;

                            for (var c = valueList.Count - 1; c > b; c--)
                            {
                                var valuec = valueList[c];
                                var diff2 = valuec - valueb;
                                if (diff2 == diff && valuea != 1487) return ($"{valuea}{valueb}{valuec}");
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}