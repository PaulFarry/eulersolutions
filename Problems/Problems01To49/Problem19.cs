using Common;
using System;

namespace Problems.Problems01To49
{
    public class Problem19 : IProblem
    {
        public int Number { get { return 19; } }

        public string Execute()
        {
            var startDate = new DateTime(1901, 1, 1);
            var endDate = new DateTime(2000, 12, 31);

            var totalSundays = 0;

            var currentDate = startDate;

            while (true)
            {
                if (currentDate.Day == 1 && currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    totalSundays++;
                }
                if (currentDate > endDate)
                {
                    break;
                }
                currentDate = currentDate.AddMonths(1);
            }

            return ($"{totalSundays}");
        }

    }
}
