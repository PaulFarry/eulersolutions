using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Parsing
    {
        public static List<List<int>> LoadSpaceSeparatedValueTree(string values)
        {
            using (var sr = new StringReader(values))
            {
                var rows = new List<List<int>>();
                while (true)
                {
                    var currentLine = sr.ReadLine();
                    if (string.IsNullOrEmpty(currentLine)) break;

                    var lineItems = currentLine.Split(' ');
                    var currentRow = new List<int>();

                    for (var lineIndex = 0; lineIndex < lineItems.Length; lineIndex++)
                    {
                        var lineItem = lineItems[lineIndex];
                        var itemValue = int.Parse(lineItem);
                        currentRow.Add(itemValue);
                    }
                    rows.Add(currentRow);
                }
                return rows;
            }
        }
    }
}
