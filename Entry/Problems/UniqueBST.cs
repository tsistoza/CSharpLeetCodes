// LeetCode 96
using System;
using System.Collections.Generic;

namespace _96
{
    public static class Globals
    {
        public static int n = 5;
    }
    public class Program
    {
        public int NumTrees(int n)
        {
            int[] dp = new int[n+1];
            dp[0] = 1;
            dp[1] = 1;
            if (n == 1) return dp[1];

            for (int i=2; i<dp.GetLength(0); i++)
            {
                int sum = 0;
                for (int j=1; j<=i; j++)
                {
                    int left = j - 1;
                    int right = i - 1 - left;
                    sum += dp[left] * dp[right];
                }
                dp[i] = sum;
            }

            return dp[n];
        }
    }
}