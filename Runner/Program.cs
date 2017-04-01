using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var solvableProblems = FindProblems();

        var problemToRun = 40;
        RunProblems(solvableProblems, problemToRun);
    }

    private static void GeneratePrimes()
    {
        //Utility.GeneratePrimes(1000000);
        var primeList = Utility.LoadPrimes(1000000);
        var minValue = primeList.Max();

        Utility.GeneratePrimes(minValue + 1, 2000000);
        return;
    }

    private static void RunProblems(SortedDictionary<int, IProblem> solvableProblems, int problemToRun)
    {
        if (problemToRun >= 1)
        {
            if (solvableProblems.ContainsKey(problemToRun))
            {
                var problem = solvableProblems[problemToRun];
                RunProblem(problem);
            }
            else
            {
                Debug.Print("No problem defined");
            }
        }
        else
        {

            foreach (var i in solvableProblems.Keys)
            {
                RunProblem(solvableProblems[i]);
            }
        }
    }

    private static void RunProblem(IProblem problem)
    {
        try
        {
            var sw = Stopwatch.StartNew();
            var answer = problem.Execute();
            sw.Stop();
            Debug.Print($"Problem {problem.Number} Answer = {answer} took {sw.ElapsedMilliseconds}ms to run");
        }
        catch (ProblemIncompleteException)
        {
            Debug.Print($"Problem {problem.Number} is incomplete");
        }
    }

    private static SortedDictionary<int, IProblem> FindProblems()
    {
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
        return solvableProblems;

    }
}
