using Common;
using System.Text;

namespace Problems.Problems01To49
{
    class Problem40 : IProblem
    {
        public int Number => 40;

        public string Execute()
        {
            var maxIndex = 1000000;
            var currentCounter = 1;

            var characterIndex = 1;
            var result = 1;

            var indexedChar = new char[1];
            var sb = new StringBuilder();
            while (sb.Length < maxIndex)
            {
                sb.Append($"{currentCounter}");
                currentCounter++;

                if (sb.Length > characterIndex)
                {
                    sb.CopyTo(characterIndex - 1, indexedChar, 0, 1);
                    var value = new string(indexedChar);
                    result *= int.Parse(value);
                    characterIndex *= 10;
                }
            }
            return result.ToString();
        }
    }
}
