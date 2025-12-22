// LeetCode 2928
using System;
using System.Collections.Generic;

namespace _2928
{
    public static class Globals
    {
        public static int n = 3;
        public static int limit = 3;
    }
    public class Program
    {
        public int DistributeCandies(int n, int limit)
        {
            int numWays = 0;
            for (int i=limit; i>=0; i--)
            {
                for (int j=Math.Min(n-i, limit); j>=0; j--)
                {
                    int k = n - i - j;
                    if (k > limit) continue;
                    numWays++;
                }
            }

            return numWays;
        }
    }
}