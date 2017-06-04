using Common;
using System.Collections.Generic;
using System.Numerics;

namespace Problems.Problems01To49
{
    class Problem45 : IProblem
    {
        public int Number => 45;

        public string Execute()
        {
            var tl = new HashSet<BigInteger>();
            var pl = new HashSet<BigInteger>();
            var hl = new HashSet<BigInteger>();

            for (BigInteger n = 1; ; n++)
            {
                var t = ((n * (n + 1)) / 2);
                var p = (n * (3 * n - 1)) / 2;
                var h = (n * (2 * n - 1));

                tl.Add(t);
                pl.Add(p);
                hl.Add(h);


                if (n > 285 && pl.Contains(t) && hl.Contains(t))
                {
                    return t.ToString();
                }
            }
        }


    }
}
