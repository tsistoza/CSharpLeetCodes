// LeetCode 1400
using System;
using System.Collections.Generic;

namespace _1400
{
    public static class Globals
    {
        public static string s = "annabelle";
        public static int k = 2;
    }
    public class Program
    {
        public bool CanConstruct(string s, int k)
        {
            if (s.Length == k) return true;

            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int i=0; i<s.Length; i++)
            {
                if (freq.ContainsKey(s[i])) freq[s[i]]++;
                else freq.Add(s[i], 1);
            }

            int odd = 0;
            List<char> chars = new List<char>(freq.Keys);
            foreach (char c in chars)
                if (freq[c] % 2 == 1) odd++;

            if (odd < k) return true;
            return false;
        }
    }
}