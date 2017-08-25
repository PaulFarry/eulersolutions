using Common;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Problems50To99
{
    class Problem72 : IProblem
    {
        public int Number => 72;

        public string Execute()
        {
            var totients = new List<int>(Utility.ListTotients(1000000));
            var result = totients.Sum(x => (long)x) - 1;

            return result.ToString();
        }
    }
}
