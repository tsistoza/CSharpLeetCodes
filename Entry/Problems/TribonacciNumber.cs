using System;
using System.Collections.Generic;
using System.Text;

namespace _1137
{
    public static class Globals
    {
        public static int n = 25;
    }
    public class Program
    {
        public int Tribonacci(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;

            for (int i=0; i+3<n+1; i++) dp[i + 3] = dp[i] + dp[i + 1] + dp[i + 2];
            return dp[n];
        }
    }
}
