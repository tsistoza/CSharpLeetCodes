// LeetCode 2787
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 10;
    public static int x = 2;
}

namespace Solution
{
    public class Program
    {
        public int NumberOfWays(int n, int x)
        {
            long mod = (long) (10000000007);
            long[,] dp = new long[n + 1, n + 1];
            dp[0, 0] = 1;
            for (int i=1; i<=n; i++)
            {
                long pow = (long) Math.Pow(i, x);
                for (int j=0; j<=n; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j >= pow)
                        dp[i, j] = (dp[i - 1, j] + dp[i - 1, j - pow]) % mod;
                }
            }
            return (int) dp[n, n];
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.NumberOfWays(Globals.n, Globals.x));
            return;
        }
    }
}