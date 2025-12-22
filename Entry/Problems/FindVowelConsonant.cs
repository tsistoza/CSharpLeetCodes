// LeetCode 3541
using System;
using System.Collections.Generic;

namespace _3541
{
    public static class Globals
    {
        public static string s = "aeiaeia";
    }
    public class Program
    {
        public int MaxFreqSum(string s)
        {
            Dictionary<char, int> vowels = new Dictionary<char, int>()
            {
                { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 }
            };
            Dictionary<char, int> consonants = new Dictionary<char, int>() { { 'b', 0 } };

            foreach (char c in s)
            {
                if (vowels.ContainsKey(c))
                {
                    vowels[c]++;
                    continue;
                }

                if (!consonants.TryAdd(c, 1))
                    consonants[c]++;
            }

            int vFreq = Enumerable.Max(vowels.Values);
            int cFreq = Enumerable.Max(consonants.Values);
            return vFreq + cFreq;
        }
    }
}