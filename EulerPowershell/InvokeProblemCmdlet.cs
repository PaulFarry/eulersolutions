using Common;
using System.Diagnostics;
using System.Management.Automation;

namespace EulerPowershell
{
    [Cmdlet(VerbsLifecycle.Invoke, "Problem")]
    [OutputType(typeof(ProblemResult))]
    public class InvokeProblemCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public int Number { get; set; }

        protected override void ProcessRecord()
        {
            var problems = ProblemService.GetProblems(typeof(Problems.DiscoveryProblem).Assembly);
            IProblem problem = null;

            var pr = new ProblemResult
            {
                Number = Number,
            };

            if (problems.TryGetValue(Number, out problem))
            {
                try
                {
                    var sw = Stopwatch.StartNew();
                    var answer = problem.Execute();
                    sw.Stop();
                    pr.Answer = answer;
                    pr.Duration = sw.ElapsedMilliseconds;

                }
                catch (ProblemIncompleteException)
                {
                    pr.Answer = $"Problem {problem.Number} is incomplete";
                }
            }
            else
            {
                pr.Answer = $"Problem not found";
            }

            WriteObject(pr);
            //base.ProcessRecord();
        }
    }
}
