// LeetCode 514
using System;
using System.Collections.Generic;

namespace _514
{
    public static class Globals
    {
        public static string ring = "dccjgocjnscdalkwrlzmsrhnprvvsvqjtqnzirtaasdeldiiokttozjfkwjghhaibtzkoepdvfkhxgmxwtwsrgiryzqljpsntjei";
        public static string key = "lsdsvjtj";
    }
    public class Program
    {
        private void dfs_man(int index, int keyIndex, string ring, string key, ref int[] dp)
        {
            if (keyIndex >= key.Length) return;
            dfs_forward(index, 0, keyIndex, ring, key, ref dp);
            dfs_backward(index, 0, keyIndex, ring, key, ref dp);
            return;
        }
        private void dfs_forward(int index, int cost, int keyIndex, string ring, string key, ref int[] dp)
        {
            if (index >= ring.Length) index -= ring.Length;
            if (key[keyIndex] == ring[index])
            {
                cost += 1;
                int newCost = -1;

                if (keyIndex > 0)
                    newCost = dp[keyIndex - 1] + cost;
                if (newCost > dp[keyIndex]) return;

                dp[keyIndex] = (keyIndex == 0) ? Math.Min(dp[keyIndex], cost) : Math.Min(newCost, dp[keyIndex]);
                dfs_man(index, keyIndex + 1, ring, key, ref dp);
            }
            else
                dfs_forward(index + 1, cost + 1, keyIndex, ring, key, ref dp); // Traverse Forward
            return;
        }
        private void dfs_backward(int index, int cost, int keyIndex, string ring, string key, ref int[] dp)
        {
            if (index < 0) index += ring.Length;

            if (key[keyIndex] == ring[index])
            {
                cost += 1;
                int newCost = -1;

                if (keyIndex > 0)
                    newCost = dp[keyIndex - 1] + cost;
                if (newCost > dp[keyIndex]) return;

                dp[keyIndex] = (keyIndex == 0) ? Math.Min(dp[keyIndex], cost) : Math.Min(newCost, dp[keyIndex]);
                dfs_man(index, keyIndex + 1, ring, key, ref dp); // Reset cost
            }
            else
                dfs_backward(index - 1, cost + 1, keyIndex, ring, key, ref dp);
            return;
        }
        public int FindRotateSteps(string ring, string key)
        {
            int[] dp = new int[key.Length];
            Array.Fill(dp, int.MaxValue);
            dfs_man(0, 0, ring, key, ref dp);
            return dp[key.Length-1];
        }
    }
}
