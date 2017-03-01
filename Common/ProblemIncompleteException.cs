using System;

namespace Common
{
    public class ProblemIncompleteException : Exception
    {
        public ProblemIncompleteException() : base()
        {

        }

        public ProblemIncompleteException(string message) : base(message)
        {

        }
    }
}
