// LeetCode 2901
using System;
using System.Collections.Generic;

namespace _2901
{
    public static class Globals
    {
        public static string[] words = { "bab", "dab", "cab" };
        public static int[] groups = { 1, 2, 2 };
    }
    public class Program
    {
        public static void prettyPrint(IList<string> list)
        {
            Console.Write("{ ");
            foreach (string s in list)
                Console.Write($"{s}, ");
            Console.WriteLine("}");
            return;
        }

        private bool checkHamDist(string s1, string s2)
        {
            int hammingDistance = 0;

            for (int i=0; i<s1.Length; i++)
            {
                if (s1[i] != s2[i]) hammingDistance++;
                if (hammingDistance > 1) return false;
            }

            return true;
        }
        public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
        {
            List<string> result = new List<string>();
            List<List<string>> dp = new List<List<string>>();
            List<int> prev = new List<int>();
            
            for (int i=0; i<words.Length; i++)
            {
                if (dp.Count < 0) // init dp
                {
                    dp.Add(new List<string>() { words[0] });
                    prev.Add(groups[i]);
                    continue;
                }

                int index = 0;
                bool append = false;
                for (; index<prev.Count; index++)
                {
                    if (prev[index] == groups[i]) continue; // check last group for each last elem of lists
                    if (dp[index][0].Length != words[i].Length) continue;
                    if (!checkHamDist(dp[index][dp[index].Count - 1], words[i])) continue;

                    dp[index].Add(words[i]);
                    prev[index] = groups[i];
                    if (dp[index].Count > result.Count) result = dp[index]; // check if longest subsequence
                    append = true;
                }

                if (!append) // If words[i] is added to end of list, no longer possible for any list starting with words[i], to be the longest subsequence
                {
                    dp.Add(new List<string>() { words[i] });
                    prev.Add(groups[i]);
                }
            }
            return result;
        }
    }
}
