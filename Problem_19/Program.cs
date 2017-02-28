using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_19
{
    class Program
    {
        static void Main(string[] args)
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

            Debug.Print($"sundays = {totalSundays}");
        }
    }
}
