using Common;
using System.Numerics;

namespace Problems
{
    public class Problem20 : IProblem
    {
        public int Number { get { return 20; } }

        public string Execute()
        {
            var startPoint = 100;
            BigInteger currentCalculation = 1;
            while (startPoint > 1)
            {
                currentCalculation = currentCalculation * (ulong)startPoint;
                startPoint--;
            }
            //Debug.Print($"{currentCalculation}");
            var digits = currentCalculation.ToString().ToCharArray();
            var finalResult = 0;

            foreach (var digit in digits)
            {
                var digitValue = int.Parse(digit.ToString());
                finalResult += digitValue;
            }
            return ($"{finalResult}");
        }
    }
}
