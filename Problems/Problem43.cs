using Common;

namespace Problems
{
    class Problem43 : IProblem
    {
        public int Number => 43;

        /*
d2d3d4=406 is divisible by 2
d3d4d5=063 is divisible by 3
d4d5d6=635 is divisible by 5
d5d6d7=357 is divisible by 7
d6d7d8=572 is divisible by 11
d7d8d9=728 is divisible by 13
d8d9d10=289 is divisible by 17
*/

        public string Execute()
        {
            var characterCombinations = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var g = Utility.GenerateCombinations(characterCombinations);
            var totalSum = (long)0;
            foreach (var i in g)
            {
                if (i.StartsWith("0")) continue;
                var d234 = int.Parse(i.Substring(1, 3));
                if (d234 % 2 == 0)
                {
                    var d345 = int.Parse(i.Substring(2, 3));
                    if (d345 % 3 == 0)
                    {
                        var d456 = int.Parse(i.Substring(3, 3));
                        if (d456 % 5 == 0)
                        {
                            var d567 = int.Parse(i.Substring(4, 3));
                            if (d567 % 7 == 0)
                            {
                                var d678 = int.Parse(i.Substring(5, 3));
                                if (d678 % 11 == 0)
                                {
                                    var d789 = int.Parse(i.Substring(6, 3));
                                    if (d789 % 13 == 0)
                                    {
                                        var d8910 = int.Parse(i.Substring(7, 3));
                                        if (d8910 % 17 == 0)
                                        {
                                            totalSum += long.Parse(i);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return totalSum.ToString();
        }
    }
}
