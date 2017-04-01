using Common;
namespace Problems.Problems01To49
{
    class Problem34 : IProblem
    {
        public int Number => 34;

        public string Execute()
        {
            var totalSum = 0;

            var upperBound = 50000;

            for (var value = 3; value < upperBound; value++)
            {
                var digitSum = 0;

                foreach (var digit in value.ToString().ToCharArray())
                {
                    var digitValue = int.Parse(digit.ToString());

                    var digitFactorial = Utility.CalculateFactorial(digitValue);
                    digitSum += digitFactorial;
                }

                if (digitSum == value)
                {
                    totalSum += value;
                }
            }
            return totalSum.ToString();
        }
    }
}
