// LeetCode 2928
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 3;
    public static int limit = 3;
}

namespace Solution
{
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
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.DistributeCandies(Globals.n, Globals.limit));
            return;
        }
    }
}