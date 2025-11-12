// LeetCode 474
using System;
using System.Collections.Generic;

namespace Solution
{
    public static class Globals
    {
        public static string[] strs = { "10", "0001", "111001", "1", "0" };
        public static int m = 5;
        public static int n = 3;
    }
    public class Program
    {
        public int FindMaxForm(string[] strs, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];
            foreach (string s in strs)
            {
                (int numZeros, int numOnes) = CountZerosAndOnes(s);
                for (int i = m; i > numZeros; i--)
                    for (int j = n; j > numOnes; j--)
                        dp[i, j] = Math.Max(dp[i, j], dp[i - numZeros,j - numOnes] + 1);
            }
            return dp[m, n];
        }

        private (int, int) CountZerosAndOnes(string nums)
        {
            int numZeros = 0, numOnes = 0;
            foreach (char c in nums)
            {
                if (c == '0') numZeros++;
                if (c == '1') numOnes++;
            }

            return (numZeros, numOnes);
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.FindMaxForm(Globals.strs, Globals.m, Globals.n));
            return;
        }
    }
}