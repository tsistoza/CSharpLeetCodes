// LeetCode 790
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 3;
}

namespace Solution
{
    public class Program
    {
        public int NumTilings(int n)
        {
            int[] dp = new int[n+1];
            for (int i=0; i<dp.Length; i++)
            {
                if (i == 0 || i == 1 || i == 2)
                {
                    dp[i] = (i == 0) ? 1 : i;
                    continue;
                }
                dp[i] = 2 * dp[i - 1] + dp[i - 3];
            }

            return dp[dp.Length-1];
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.NumTilings(Globals.n));
            return;
        }
    }
}