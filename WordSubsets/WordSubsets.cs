﻿// LeetCode 916
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string[] words1 = { "amazon", "apple", "facebook", "google", "leetcode" };
    public static string[] words2 = { "e", "o" };
    public static string[] words1a = { "amazon", "apple", "facebook", "google", "leetcode" };
    public static string[] words2a = { "l", "e" };
}

namespace Solution
{
    public class Program
    {
        private bool isSubset(string a, string b)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (char c in b)
            {
                if (count.ContainsKey(c)) count[c]++;
                else count.Add(c, 1);
            }


            foreach (char c in a)
            {
                if (!count.ContainsKey(c))
                    continue;
                if (count[c] <= 0) continue;
                count[c]--;
            }

            List<char> list = new List<char>(count.Keys);
            foreach (char c in list)
                if (count[c] > 0) return false;

            return true;
        }
        public List<string> WordSubsets(string[] words1, string[] words2)
        {
            List<string> result = new List<string>();
            foreach (string word in words1)
            {
                int count = words2.Length;
                foreach (string word2 in words2)
                    if (!isSubset(word, word2)) count--;

                if (count == words2.Length) result.Add(word);
            }
                
            return result;
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach (string s in obj.WordSubsets(Globals.words1, Globals.words2))
                Console.Write($"{s} ");
            Console.WriteLine();

            foreach (string s in obj.WordSubsets(Globals.words1a, Globals.words2a))
                Console.Write($"{s} ");
            Console.WriteLine();
            return;
        }
    }
}