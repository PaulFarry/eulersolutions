using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Problems.Problems01To49
{
    public class Problem17 : IProblem
    {
        public int Number { get { return 17; } }

        public string Execute()
        {
            var nc = new NumberToTextConverter { IncludeCents = false, WholeNumberName = string.Empty, DecimalNumberName = string.Empty };

            var totalResult = new StringBuilder();

            var result = nc.ShowValue(100);
            for (var currentNumber = 1; currentNumber <= 1000; currentNumber++)
            {
                var output = nc.ShowValue(currentNumber);
                totalResult.Append(output);
                totalResult.Append(" ");
            }

            var h = new HashSet<char>();
            var totalCharacters = 0;
            foreach (var character in totalResult.ToString().ToCharArray())
            {
                if (char.IsLetter(character))
                {
                    h.Add(character);
                    totalCharacters++;
                }
            }
            return totalCharacters.ToString();
        }
    }

    public class NumberToTextConverter
    {
        private static Dictionary<int, string> BaseUnits;
        private static Dictionary<long, string> MajorValues;

        private static string ZeroValue = "No";
        static NumberToTextConverter()
        {
            BaseUnits = new Dictionary<int, string>();
            BaseUnits.Add(0, "");
            BaseUnits.Add(1, "One");
            BaseUnits.Add(2, "Two");
            BaseUnits.Add(3, "Three");
            BaseUnits.Add(4, "Four");
            BaseUnits.Add(5, "Five");
            BaseUnits.Add(6, "Six");
            BaseUnits.Add(7, "Seven");
            BaseUnits.Add(8, "Eight");
            BaseUnits.Add(9, "Nine");
            BaseUnits.Add(10, "Ten");
            BaseUnits.Add(11, "Eleven");
            BaseUnits.Add(12, "Twelve");
            BaseUnits.Add(13, "Thirteen");
            BaseUnits.Add(14, "Fourteen");
            BaseUnits.Add(15, "Fifteen");
            BaseUnits.Add(16, "Sixteen");
            BaseUnits.Add(17, "Seventeen");
            BaseUnits.Add(18, "Eighteen");
            BaseUnits.Add(19, "Nineteen");
            BaseUnits.Add(20, "Twenty");
            BaseUnits.Add(30, "Thirty");
            BaseUnits.Add(40, "Forty");
            BaseUnits.Add(50, "Fifty");
            BaseUnits.Add(60, "Sixty");
            BaseUnits.Add(70, "Seventy");
            BaseUnits.Add(80, "Eighty");
            BaseUnits.Add(90, "Ninety");

            MajorValues = new Dictionary<long, string>();
            MajorValues.Add(1, string.Empty);
            MajorValues.Add(1000, "Thousand");
            MajorValues.Add(1000000, "Million");
            MajorValues.Add(1000000000, "Billion");
        }

        public bool UppercaseDisplay { get; set; }
        public bool IncludeCents { get; set; }

        public string WholeNumberName { get; set; }
        public string DecimalNumberName { get; set; }

        public NumberToTextConverter()
        {
            UppercaseDisplay = true;
            IncludeCents = true;
            WholeNumberName = "dollars";
            DecimalNumberName = "cents";
        }

        private string GroupProcessor(bool hasPreviousInput, int num, long displayUnit)
        {
            string displayText = MajorValues[displayUnit];

            int hundreds = num / 100;
            int hundredsremainder = num - (hundreds * 100);
            StringBuilder output = new StringBuilder();

            if (num != 0)
            {
                if (hundreds == 0)
                {
                    if (hasPreviousInput)
                        output.Append("and ");
                }
                else
                {
                    output.AppendFormat("{0} Hundred ", BaseUnits[hundreds]);

                    if (hundredsremainder != 0)
                        output.Append("and ");

                }


                if (hundredsremainder > 0)
                {
                    if (hundredsremainder < 20)
                    {
                        output.AppendFormat("{0} ", BaseUnits[hundredsremainder]);
                    }
                    else
                    {
                        int tens = (hundredsremainder / 10);
                        int units = hundredsremainder - (tens * 10);

                        if (tens == 0)
                        {
                            output.AppendFormat("{0} ", BaseUnits[units]);
                        }
                        else
                        {
                            if ((units == 0))
                            {
                                output.AppendFormat("{0} ", BaseUnits[tens * 10], BaseUnits[units]);
                            }
                            else
                            {
                                output.AppendFormat("{0}-{1} ", BaseUnits[tens * 10], BaseUnits[units]);
                            }
                        }
                    }
                }
                output.AppendFormat("{0} ", displayText);
            }
            return output.ToString();
        }

        public string ShowValue(decimal value)
        {

            if ((value <= 0))
                throw new ArgumentException("Value must be Greater than 0, otherwise an invoice is required", "value");

            string result = null;
            decimal dollars = Math.Floor(value);
            decimal cents = Math.Floor(Math.Round((value - dollars) * 100));

            List<int> centsBreakDown = BreakDown(cents);
            List<int> dollarsBreakDown = BreakDown(dollars);

            string dollarsText = DisplayResult(dollarsBreakDown, true, WholeNumberName);
            string centsText = DisplayResult(centsBreakDown, true, DecimalNumberName);

            string formatDefinition = "{0}{1}";

            if (dollarsBreakDown.Count > 0 && centsBreakDown.Count > 0)
            {
                if (IncludeCents)
                {
                    formatDefinition = "{0} and {1}";
                }
                else
                {
                    formatDefinition = "{0}";
                }
            }

            result = string.Format(formatDefinition, dollarsText, centsText).Trim();
            if (UppercaseDisplay)
            {
                return result.ToUpperInvariant();
            }
            else
            {
                return result;
            }
        }

        private string DisplayResult(List<int> results, bool includeZero, string unitDescription)
        {
            StringBuilder sb = new StringBuilder();
            long index = 1;
            List<string> finalOutput = new List<string>();
            List<int> inputReversed = new List<int>(results);
            inputReversed.Reverse();

            index = (long)(1 * Math.Pow(1000, (results.Count - 1)));

            string preResult = null;
            if (results.Count == 0 || (results.Count == 1 && (results[0] == 0)) && includeZero)
            {
                preResult = ZeroValue;
            }
            else
            {
                bool previousInput = false;
                foreach (int r in inputReversed)
                {
                    finalOutput.Add(this.GroupProcessor(previousInput, r, index));
                    previousInput = true;
                    index /= 1000;
                }

                foreach (string b in finalOutput)
                {
                    sb.Append(b);
                }

                preResult = sb.ToString().Trim();

            }

            if (preResult.Length > 0)
            {
                preResult += " " + unitDescription;
            }
            return preResult;

        }


        private List<int> BreakDown(decimal num)
        {
            List<int> result = new List<int>();

            if (num == 0)
            {
                result.Add(0);
                return result;
            }

            decimal currentNumber = num;

            int nextValue = 0;
            bool continueProcessing = true;



            while (continueProcessing)
            {
                if (currentNumber >= 1000)
                {
                    nextValue = (int)(currentNumber - ((currentNumber / 1000) * 1000));
                    currentNumber = Math.Floor(currentNumber / 1000);
                }
                else
                {
                    nextValue = (int)currentNumber;
                    continueProcessing = false;
                }
                result.Add(nextValue);
            }

            return result;
        }
    }

}
