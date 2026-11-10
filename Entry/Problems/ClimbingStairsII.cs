// LeetCode 3693
using System;
using System.Collections.Generic;

namespace _3693
{
    public static class Globals
    {
        public static int n = 3; 
        public static int[] costs = new int[] { 9, 8, 3 };
    }

    public class Program
    {
        public int ClimbStairs(int n, int[] costs)
        {
            int[] dp = new int[n+1]; // @ dp[i] is the minimum total cost, where i is the step #.
            dp[1] = costs[0] + 1;
            if (n == 1) return dp[1];
            dp[2] = costs[1] + Math.Min(dp[1] + 1, 4);
            if (n == 2) return dp[2];
            

            //Console.WriteLine($"dp[1] = {dp[1]}, dp[2]={dp[2]}, dp[3]={dp[3]}");
            for (int i=3; i<=n; i++)
            {
                int path1 = dp[i - 1] + 1;
                int path2 = dp[i - 2] + 4;
                int path3 = dp[i - 3] + 9;
                //Console.WriteLine($"Possible Paths: path1=step{i - 1} -> step{i}={path1} | path2=step{i - 2} -> step{i}={path2} | path3=step{i - 3} -> step{i}={path3}");
                dp[i] = costs[i-1] + Math.Min(Math.Min(path1, path2), path3);
            }

            return dp[n];
        }
    }
}
