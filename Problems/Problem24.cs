using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class Problem24 : IProblem
    {
        public int Number => 24;

        private List<string> Generate(char[] characters)
        {
            var result = new List<string>();

            var offsetArray = new int[characters.Length];
            var totalLength = characters.Length;

            for (var index = 0; index < totalLength; index++)
            {
                offsetArray[index] = 0;
            }

            var outputValue = new string(characters);
            result.Add(outputValue);


            var i = 0;
            while (i < totalLength)
            {
                if (offsetArray[i] < i)
                {
                    if ((i % 2) == 0)
                    {
                        var tmp = characters[0];
                        characters[0] = characters[i];
                        characters[i] = tmp;
                    }
                    else
                    {
                        var tmp = characters[offsetArray[i]];
                        characters[offsetArray[i]] = characters[i];
                        characters[i] = tmp;
                    }

                    outputValue = new string(characters);
                    result.Add(outputValue);
                    offsetArray[i] += 1;
                    i = 0;
                }
                else
                {
                    offsetArray[i] = 0;
                    i += 1;
                }
            }
            result.Sort();
            return result;
        }
        /*
         * Psuedocode from Wikipedia
        procedure generate(n : integer, A : array of any):
            c : array of int

            for i := 0; i < n; i += 1 do
                c[i] := 0
            end for

            output(A)

            i := 0;
            while i < n do
                if  c[i] < i then
                    if i is even then
                        swap(A[0], A[i])
                    else
                        swap(A[c[i]], A[i])
                    end if
                    output(A)
                    c[i] += 1
                    i := 0
                else
                    c[i] := 0
                    i += 1
                end if
            end while
         */
        public string Execute()
        {
            var characterCombinations = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var g = Generate(characterCombinations);
            return g[1000000 - 1];
        }
    }
}
