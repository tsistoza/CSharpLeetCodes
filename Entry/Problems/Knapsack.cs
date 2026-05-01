using System;
using System.Collections.Generic;

// Just doing this to get more practice with knapsack problems
namespace KnapSackProblem
{
    public static class Globals
    {
        public static int[] val = { 1, 2, 3 };
        public static int[] wt = { 4, 5, 1 };
        public static int capacity = 3;
    }
    public class Program
    {
        public int MaxValue(int[] val, int[] wt, int capacity)
        {
            int[] dp = new int[capacity + 1];

            for (int i=0; i<val.Length; i++)
            {
                for (int j=capacity; j>0; j--)
                {
                    if (wt[i] > j) continue;
                    dp[j] = Math.Max(dp[j], dp[j - wt[i]] + val[i]);
                    Console.WriteLine($"dp[{j}] = {dp[j]} we pick i={i}, with weight = {wt[i]}");
                }

            }
            return dp[capacity];
        }
    }
}
