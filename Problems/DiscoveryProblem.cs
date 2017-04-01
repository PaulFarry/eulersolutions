using Common;
using System;

namespace Problems
{
    /// <summary>
    /// This is the template class to allow for dynamic discovery
    /// </summary>
    public class DiscoveryProblem : IProblem
    {
        public int Number => -1;

        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
