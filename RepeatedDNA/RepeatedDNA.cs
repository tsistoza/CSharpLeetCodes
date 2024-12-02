// LeetCode 187
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
    public static string s1 = "AAAAAAAAAAAAA";
}

namespace Solution
{
    public class Program
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            List<string> sequences = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (!(i + 10 < s.Length))
                    break;
                string subseq = s.Substring(i, 10);
                if (dict.ContainsKey(subseq))
                {
                    dict[subseq]++;
                    if (dict[subseq] > 2) continue;
                    sequences.Add(subseq);
                }
                else dict.Add(subseq, 1);
            }
            return sequences;
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach(string seq in obj.FindRepeatedDnaSequences(Globals.s))
                Console.Write($"{seq} ");
            Console.WriteLine();
            foreach (string seq in obj.FindRepeatedDnaSequences(Globals.s1))
                Console.Write($"{seq} ");
            Console.WriteLine();
            return;
        }
    }
}