using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    /// <summary>
    /// This is the template class to allow for dynamic discovery
    /// </summary>
    public class DiscoveryProblem : IProblem
    {
        public int Number { get { return -1; } }

        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
