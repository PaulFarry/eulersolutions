using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common
{
    public static class ProblemService
    {
        private static SortedDictionary<int, IProblem> problems;

        public static SortedDictionary<int, IProblem> GetProblems(Assembly assembly)
        {
            if (problems == null)
            {
                problems = new SortedDictionary<int, IProblem>();
                var problemBase = typeof(IProblem);

                foreach (var t in assembly.GetTypes())
                {
                    if (problemBase.IsAssignableFrom(t))
                    {
                        var instance = (IProblem)Activator.CreateInstance(t);
                        if (instance.Number > 0)
                        {
                            problems.Add(instance.Number, instance);
                        }
                    }

                }
            }
            return problems;

        }
    }
}
