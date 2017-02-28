using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxValue = 1000;
            var values = new List<int>();
            for (var i = 1; i < maxValue; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    values.Add(i);
                }
            }
            var total = values.Sum();
            Debug.Print(total.ToString());
        }
    }
}
