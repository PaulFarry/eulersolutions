using ProtoBuf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Common
{
    [ProtoContract]
    public class Primes

    {
        public Primes()
        {
            Values = new List<long>();
        }


        [ProtoMember(1)]
        public long MinValue { get; set; }
        [ProtoMember(2)]
        public long MaxValue { get; set; }
        [ProtoMember(3)]
        public List<long> Values { get; set; }


        public static void ConvertPrimes(List<long> original, string outputFilePath)
        {
            var p = new Primes();
            p.AddValues(original);
            using (var fs = new FileStream(outputFilePath, FileMode.Create))
            {
                Serializer.Serialize(fs, p);
            }
        }

        private void AddValues(List<long> original)
        {
            Values.AddRange(original);
            MinValue = original.Min();
            MaxValue = original.Max();
        }

        public static void GeneratePrimes(long minValue, long maxValue, string inputFilePath, string outputFilePath)
        {
            var p = new Primes();
            if (File.Exists(inputFilePath))
            {
                using (var stream = File.Create(outputFilePath))
                {
                    p = Serializer.Deserialize<Primes>(stream);
                    minValue = p.MaxValue + 1;
                }
            }
            var newValues = GeneratePrimes(minValue, maxValue);
            p.AddValues(newValues);

            using (var stream = File.Create(outputFilePath))
            {
                Serializer.Serialize(stream, p);
            }
        }

        public static List<long> GeneratePrimes(long minValue, long maxValue)
        {
            var items = new List<long>();
            for (var i = minValue; i < maxValue; i++)
            {
                if (Utility.IsPrime(i))
                {
                    items.Add(i);
                }
            }
            return items;
        }

        public static void GeneratePrimes(long maximumValue)
        {
            GeneratePrimes(1, maximumValue);
        }

        public static List<long> LoadPrimes()
        {
            return LoadPrimes(int.MaxValue);
        }

        public static List<long> LoadPrimes(long maximumValue)
        {
            var values = new List<long>();

            using (var primeResourceFileData = Assembly.GetExecutingAssembly().GetManifestResourceStream("Common.PrimeList.dat"))
            {
                var primes = Serializer.Deserialize<Primes>(primeResourceFileData);
                foreach (var p in primes.Values)
                {
                    if (p <= maximumValue)
                    {
                        values.Add(p);
                    }
                }
            }
            return values;
        }
    }
}
