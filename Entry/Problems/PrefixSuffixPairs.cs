// LeetCode 3042
using System;
using System.Collections.Generic;

namespace _3402
{
    public static class Globals
    {
        public static List<string> words = new List<string>() { "a", "aba", "ababa", "aa" };
        public static List<string> words1 = new List<string>() { "pa", "papa", "ma", "mama" };
    }
    public class Program
    {
        private bool isPrefixAndSuffix(string str1, string str2)
        {
            if (str2.Length < str1.Length) return false;

            // Check Prefix
            for (int i=0; i<str1.Length; i++)
                if (str2[i] != str1[i]) return false;

            // Check Suffix
            for (int i = str2.Length - str1.Length,j=0; i < str2.Length; i++,j++)
                if (str2[i] != str1[j]) return false;
            return true;
        }

        public int CountPrefixSuffixPairs(List<string> words)
        {
            int count = 0;
            for (int i=0; i<words.Count; i++)
                for (int j=i+1; j<words.Count; j++)
                    if (isPrefixAndSuffix(words[i], words[j])) count++;
            return count;
        }
    }
}
