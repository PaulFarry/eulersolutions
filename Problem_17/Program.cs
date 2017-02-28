using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_17
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetWord(950);
            Debug.Print(data);

        }

        private static string GetWord(int value, StringBuilder builder = null)
        {
            if (builder == null) builder = new StringBuilder();

            if (value < 10)
            {
                switch (value)
                {
                    case 1:
                        return "One";
                    case 2:
                        return "Two";
                    case 3:
                        return "Three";
                    case 4:
                        return "Four";
                    case 5:
                        return "Five";
                    case 6:
                        return "Six";
                    case 7:
                        return "Seven";
                    case 8:
                        return "Eight";
                    case 9:
                        return "Nine";
                }
            }
            else if (value < 20)
            {
                switch (value)
                {
                    case 10:
                        return "Ten";
                    case 11:
                        return "Eleven";
                    case 12:
                        return "Twelve";
                    case 13:
                        return "Thirteen";
                    case 14:
                        return "Fourteen";
                    case 15:
                        return "Fifteen";
                    case 16:
                        return "Sixteen";
                    case 17:
                        return "Seventeen";
                    case 18:
                        return "Eighteen";
                    case 19:
                        return "Nineteen";
                }
            }
            else if (value > 20 && value < 100)
            {
                var item = value / 10;
                switch (item)
                {
                    case 20:
                        builder.Append("Twenty");
                        break;
                    case 30:
                        builder.Append("Thirty");
                        break;
                    case 40:
                        builder.Append("Forty");
                        break;
                    case 50:
                        builder.Append("Fifty");
                        break;
                    case 60:
                        builder.Append("Sixty");
                        break;
                    case 70:
                        builder.Append("Seventy");
                        break;
                    case 80:
                        builder.Append("Eighty");
                        break;
                    case 90:
                        builder.Append("Ninety");
                        break;
                }
            }
            else if (value >= 100 && value < 1000)
            {
                var item = value / 100;
                builder.Append(GetWord(item, builder));
                builder.Append(" Hundred");
                GetWord(value - (item * 100), builder);
            }
            else
            {
                var item = value / 1000;
                builder.Append(GetWord(item));
                builder.Append(" Thousand");
            }
            return builder.ToString();
        }
    }
}
