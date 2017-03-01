using Common;

namespace Problems
{
    public class Problem9 : IProblem
    {
        public int Number { get { return 9; } }

        public string Execute()
        {
            throw new ProblemIncompleteException();

            var a = 1;
            var b = 2;
            var c = 3;

            while (true)
            {
             //   Debug.Print($"{a} {b} {c}");
                if (((a ^ 2) + (b ^ 2)) == (c ^ 2))
                {
                    if (a + b + c == 1000)
                    {
                        return ($"Winner {a} {b} {c}");
                        break;
                    }
                }

                if (a < b - 1)
                {
                    a++;
                }
                else
                {
                    a = 1;
                    if (b < c - 1)
                    {
                        b++;
                    }
                    else
                    {
                        b = 2;
                        c++;
                    }
                }
            }
        }
    }
}
