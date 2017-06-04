using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        var solvableProblems = ProblemService.GetProblems(typeof(Problems.DiscoveryProblem).Assembly);

        var problemToRun = 97;
        RunProblems(solvableProblems, problemToRun);
    }


    private static FileInfo GetPrimeFile()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var fileInfo = new FileInfo(Path.Combine(appData, "Euler", "PrimeList.dat"));
        fileInfo.Directory.Create();
        return fileInfo;
    }

    private static void GeneratePrimes()
    {
        var primeList = Primes.LoadPrimes();
        Primes.ConvertPrimes(primeList, GetPrimeFile().FullName);
        //Now move the output file to the Development folder as an embedded resource
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
            string answer = string.Empty;
            var executions = 1;
            for (var i = 1; i <= executions; i++)
            {
                answer = problem.Execute();
            }
            sw.Stop();
            Debug.Print($"Problem {problem.Number} Answer = {answer} took {sw.ElapsedMilliseconds}ms to run");
            Debug.Print($"Average {sw.ElapsedMilliseconds / (double)executions}");
        }
        catch (ProblemIncompleteException)
        {
            Debug.Print($"Problem {problem.Number} is incomplete");
        }
    }
}
