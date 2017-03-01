using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        var problemToRun = 20;

        var solvableProblems = new SortedDictionary<int, IProblem>();

        var problemBase = typeof(IProblem);

        foreach (var t in typeof(Problems.DiscoveryProblem).Assembly.GetTypes())
        {
            if (problemBase.IsAssignableFrom(t))
            {
                var instance = (IProblem)Activator.CreateInstance(t);
                if (instance.Number > 0)
                {
                    solvableProblems.Add(instance.Number, instance);
                }
            }
        }
        foreach (var i in solvableProblems.Keys)
        {
            problemToRun = i;
            if (solvableProblems.ContainsKey(problemToRun))
            {
                try
                {
                    var sw = Stopwatch.StartNew();
                    var answer = solvableProblems[problemToRun].Execute();
                    sw.Stop();
                    Debug.Print($"Problem {problemToRun} Answer = {answer} took {sw.ElapsedMilliseconds}ms to run");
                }
                catch (ProblemIncompleteException)
                {
                    Debug.Print($"Problem {problemToRun} is incomplete");
                }
            }
            else
            {
                Debug.Print("No problem defined");
            }
        }
    }
}
