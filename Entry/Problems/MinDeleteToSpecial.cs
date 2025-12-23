// LeetCode 3085
using System;
using System.Collections.Generic;

namespace _3085
{
    public static class Globals
    {
        public static string word = "aaabaaa";
        public static int k = 2;
    }
    public class Program
    {
        public int MinimumDeletions(string word, int k)
        {
            Dictionary<char, int> kvp = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (!kvp.TryAdd(c, 1))
                    kvp[c]++;
            }

            List<int> sorted = new List<int>();
            foreach (int i in kvp.Values)
                sorted.Add(i);
            kvp.Clear();

            sorted.Sort();

            int minDelete = int.MaxValue;
            for (int i=0; i<sorted.Count; i++)
            {
                int currDelete = 0;
                for (int j=0; j<sorted.Count; j++)
                {
                    if (i == j) continue;
                    Console.WriteLine($"i = {i}, j = {j}");
                    if (i < j)
                    {
                        int delete = (sorted[j] - sorted[i]) - k;
                        currDelete += (delete > 0) ? delete : 0;
                    }
                    if (i > j)
                    {
                        currDelete += sorted[j];
                    }
                }
                minDelete = Math.Min(minDelete, currDelete);
            }

            return minDelete;
        }
    }
}