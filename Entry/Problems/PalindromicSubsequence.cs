// LeetCode 516
using System;
using System.Collections.Generic;

namespace _516
{
    public static class Globals
    {
        public static string s = "bbbab";
    }

    public class Program
    {
        private static void FillArray(ref int[,] dp, int val)
        {
            for (int i = 0; i<dp.GetLength(0); i++)
                for (int j=0; j<dp.GetLength(1); j++)
                    dp[i, j] = val;
            return;
        }

        private int FindLength(int i, int j, ref string s, ref int[,] dp)
        {
            if (i > j) return 0;
            if (i == j) return 1;

            if (s[i] == s[j] && dp[i + 1, j - 1] == -1) return FindLength(i + 1, j - 1, ref s, ref dp) + 2;
            else if (s[i] == s[j] && dp[i + 1, j - 1] != -1) return dp[i + 1, j - 1];

            if (s[i] != s[j] && dp[i + 1, j] == -1) return Math.Max(FindLength(i + 1, j, ref s, ref dp), FindLength(i, j - 1, ref s, ref dp));
            return Math.Max(dp[i + 1, j], dp[i, j - 1]);
        }

        public int LongestPalindromeSubseq(string s)
        {
            if (s.Length == 1) return 1;
            if (s.Length == 2) return (s[0] == s[1]) ? 2 : 1;

            int max = 0;

            int[,] dp = new int[s.Length, s.Length];
            FillArray(ref dp, -1);

            for (int i=0; i<s.Length; i++)
            {
                for (int j=0; j<s.Length; j++)
                {
                    dp[i, j] = FindLength(i, j, ref s, ref dp);
                    max = Math.Max(max, dp[i, j]);
                }
            }


            return max;
        }
    }
}
