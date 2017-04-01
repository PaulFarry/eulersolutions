using Common;
using System.Diagnostics;

namespace Problems.Problems01To49.Problems01To49
{
    public class Problem9 : IProblem
    {
        public int Number { get { return 9; } }

        public string Execute()
        {

            var a = 1;
            var b = 2;
            var c = 3;

            while (true)
            {
                //   Debug.Print($"{a} {b} {c}");
                if (((a * a) + (b * b)) == (c * c))
                {
                    if (a + b + c == 1000)
                    {
                        var result = a * b * c;
                        return result.ToString();
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
