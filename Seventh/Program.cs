using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите N");
        int n = Convert.ToInt32(Console.ReadLine());
        var S = new string[n];
        for (int i = 0; i < n; i++) S[i] = i.ToString();
        Console.WriteLine("Введите K");
        int k = Convert.ToInt32(Console.ReadLine());

        Permute.SubsetSelection(S, k, false);
    }

    static class Permute
    {
        public static void SubsetSelection(IEnumerable<string> S, int? n,
                                            bool allowPermutation)
        {
            var result = new List<string>();
            M(S.ToList(), "", result, n, allowPermutation);

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Count: {0}", result.Count);
        }
        static void M(List<string> S, string s, List<string> result, int? n,
                       bool allowPermutation)
        {
            for (int i = 0; i < S.Count; i++)
            {
                bool allowPermutationTest = allowPermutation
                    || !(s.Length > 0 && s[s.Length - 1] > S[i][0]);

                if (!allowPermutationTest) continue;

                string head = s + S[i];
                var tail = new List<string>();
                tail.AddRange(S);
                tail.RemoveAt(i);

                if (n == null || head.Length == n)
                {
                    result.Add(string.Format("{0}", head));
                }

                M(tail, head, result, n, allowPermutation);
            }
        }
    }

    static class BitMapping
    {
        public static void ShowBitMaps(int n)
        {
            var list = GenerateAllBitMappings(n);
            foreach (string s in list) Console.WriteLine(s);
        }
        public static void SubsetSelection(string[] S)
        {
            PrintAllCombinations(S);
        }

        // Implemented with Inspiration from a source code seen on the Internet
        static string GetNexBitMapping(string str)
        {
            int p0 = str.LastIndexOf('0');
            if (p0 == -1) return string.Empty;
            int len = str.Length;
            str = str.Substring(0, p0) + "1";
            str = str.PadRight(len, '0');
            return str;
        }

        static List<string> GenerateAllBitMappings(int len)
        {
            var list = new List<string>();
            string bitMapping = "1".PadLeft(len, '0');
            list.Add(bitMapping);
            while (bitMapping != string.Empty)
            {
                bitMapping = GetNexBitMapping(bitMapping);
                if (bitMapping != string.Empty)
                {
                    list.Add(bitMapping);
                }
            }
            return list;
        }

        static void PrintAllCombinations(string[] data)
        {
            var allBitMappings = GenerateAllBitMappings(data.Length);
            foreach (string bitMapping in allBitMappings)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (bitMapping[i] == '1') Console.Write(data[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Count: {0}", allBitMappings.Count);
        }
    }
}