// LeetCode 187
using System;
using System.Collections.Generic;

namespace _187
{
    public static class Globals
    {
        public static string s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
    }
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
    }
}
