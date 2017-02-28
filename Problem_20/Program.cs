using System.Diagnostics;
using System.Numerics;

namespace Problem_20
{
    class Program
    {
        static void Main(string[] args)
        {
            var startPoint = 100;
            BigInteger currentCalculation = 1;
            while (startPoint > 1)
            {
                currentCalculation = currentCalculation * (ulong)startPoint;
                startPoint--;
            }
            Debug.Print($"{currentCalculation}");
            var digits = currentCalculation.ToString().ToCharArray();
            var finalResult = 0;

            foreach(var digit in digits)
            {
                var digitValue = int.Parse(digit.ToString());
                finalResult += digitValue;
            }
            Debug.Print($"{finalResult}");
        }
    }
}
