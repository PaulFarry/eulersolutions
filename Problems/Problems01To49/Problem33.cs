using Common;
using System.Diagnostics;

namespace Problems.Problems01To49
{
    class Problem33 : IProblem
    {
        public int Number => 33;

        public string Execute()
        {
            var numeratorResult = 1;
            var denominatorResult = 1;

            for (var numerator = 10; numerator <= 99; numerator++)
            {
                for (var denominator = numerator + 1; denominator <= 99; denominator++)
                {
                    var numMod = numerator % 10;
                    var denMod = denominator % 10;
                    if (numMod == 0 || denMod == 0) continue;
                    var numDiv = numerator / 10;
                    var denDiv = denominator / 10;
                    if (numMod != denDiv) continue;

                    if (denominator * numDiv == numerator * denMod)
                    {
                        numeratorResult *= numerator;
                        denominatorResult *= denominator;
                    }
                }
            }
            var maxCap = Utility.GreatestCommonDenominator(numeratorResult, denominatorResult);
            var finalDenominator = denominatorResult / maxCap;

            return finalDenominator.ToString();
        }
    }
}
