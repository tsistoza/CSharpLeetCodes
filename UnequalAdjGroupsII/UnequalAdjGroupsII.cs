// LeetCode 2901
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string[] words = { "bab", "dab", "cab" };
    public static int[] groups = { 1, 2, 2 };
}

namespace Solution
{
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

            return (hammingDistance == 1);
        }
        public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
        {
            List<int> countGroups = new List<int>(Enumerable.Repeat(0, groups.Length));
            int numGroups = 0;
            foreach (int i in groups)
            {
                countGroups[i-1]++;
                if (countGroups[i-1] == 1) numGroups++;
            }

            List<string> result = new List<string>();
            List<List<string>> dp = new List<List<string>>();
            List<int> prev = new List<int>();
            
            for (int i=0; i<words.Length; i++)
            {
                if (dp.Count < 0)
                {
                    dp.Add(new List<string>() { words[0] });
                    prev.Add(groups[i]);
                    continue;
                }

                int index = 0;
                bool append = false;
                for (; index<prev.Count; index++)
                {
                    if (prev[index] == groups[i]) continue;
                    if (dp[index][0].Length != words[i].Length) continue;
                    if (!checkHamDist(dp[index][dp[index].Count - 1], words[i])) continue;

                    dp[index].Add(words[i]);
                    prev[index] = groups[i];
                    if (dp[index].Count > result.Count) result = dp[index];
                    append = true;
                }

                if (!append) 
                {
                    dp.Add(new List<string>() { words[i] });
                    prev.Add(groups[i]);
                }
            }
            return result;
        }
        public static void Main()
        {
            Program obj = new Program();
            Program.prettyPrint(obj.GetWordsInLongestSubsequence(Globals.words, Globals.groups));
            return;
        }
    }
}