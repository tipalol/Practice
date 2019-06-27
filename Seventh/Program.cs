using System;
using System.Collections.Generic;
using System.Linq;

class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите N");
        int n = 0; int k = 0;
        try
        {
            n = Convert.ToInt32(Console.ReadLine());
            var S = new string[n];
            for (int i = 0; i < n; i++) S[i] = i.ToString();
            Console.WriteLine("Введите K");
            k = Convert.ToInt32(Console.ReadLine());
            Permute.SubsetSelection(S, k, false);
        } catch (Exception)
        {
            Console.WriteLine("Произошла ошибка при попытке считать число");
        }

        
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
}