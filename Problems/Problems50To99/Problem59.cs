using Common;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Problems.Problems50To99
{
    class Problem59 : IProblem
    {

        public int Number => 59;

        public string Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = "Problems";
            var resourceName = $"{nameSpace}.DataFiles.p59.txt";

            var data = string.Empty;

            var sourceData = new MemoryStream();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var sr = new StreamReader(stream))
            {
                var text = sr.ReadToEnd();
                var items = text.Split(',');
                foreach (var i in items)
                {
                    var value = int.Parse(i);
                    sourceData.WriteByte((byte)value);
                }
            }

            var possibleCipher = "abcdefghijklmnopqrstuvwxyz";
            var characters = possibleCipher.ToCharArray();

            var sb = new char[3];

            var combinations = new List<string>();
            foreach (var a in characters)
            {
                sb[0] = a;
                foreach (var b in characters)
                {
                    sb[1] = b;
                    foreach (var c in characters)
                    {
                        sb[2] = c;
                        combinations.Add(new string(sb));
                    }
                }
            }

            var total = 0;

            foreach (var cipher in combinations)
            {
                var badSequence = false; ;
                var cipherBytes = cipher.ToCharArray();
                var cipherIndex = 0;
                sourceData.Seek(0, SeekOrigin.Begin);
                using (var decrypted = new MemoryStream((int)sourceData.Length))
                {
                    while (sourceData.Position < sourceData.Length)
                    {
                        var dec = (int)cipherBytes[cipherIndex];
                        var currentChar = (byte)sourceData.ReadByte();
                        var t = (byte)(dec ^ currentChar);

                        var c = (char)t;

                        if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c))
                        {
                            decrypted.WriteByte(t);

                            cipherIndex++;
                            if (cipherIndex >= cipherBytes.Length)
                            {
                                cipherIndex = 0;
                            }
                        }
                        else
                        {
                            badSequence = true;
                            break;
                        }
                    }

                    if (!badSequence)
                    {

                        decrypted.Seek(0, SeekOrigin.Begin);
                        while (decrypted.Position < decrypted.Length)
                        {
                            total += decrypted.ReadByte();
                        }

                        /*
                        decrypted.Seek(0, SeekOrigin.Begin);
                        using (var sr = new StreamReader(decrypted))
                        {
                            var text  = sr.ReadToEnd();
                            Debug.Print(text);
                        }
                        */
                    }
                }



            }

            return total.ToString();
        }
    }
}
