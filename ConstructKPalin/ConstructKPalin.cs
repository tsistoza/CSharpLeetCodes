// LeetCode 1400
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string s = "annabelle";
    public static int k = 2;
    public static string s1 = "leetcode";
    public static int k1 = 3;
    public static string s2 = "true";
    public static int k2 = 4;
}

namespace Solution
{
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
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CanConstruct(Globals.s, Globals.k));
            Console.WriteLine(obj.CanConstruct(Globals.s1, Globals.k1));
            Console.WriteLine(obj.CanConstruct(Globals.s2, Globals.k2));
            return;
        }
    }
}