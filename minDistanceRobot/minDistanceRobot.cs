using Solution;
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> robot = new List<int>() { 0, 4, 6 };
    public static List<List<int>> factories = new List<List<int>>() { new List<int>() { 2, 2 },
                                                                      new List<int>() { 6, 2 }, };

}

namespace Solution
{
    public class Program
    {
        public long MinimumTotalDistance(List<int> robot, List<List<int>> factories)
        {
            robot.Sort();
            factories.Sort((a, b) => a[0].CompareTo(b[0]));

            int m = robot.Count;
            int n = factories.Count;

            long[,] dp = new long[m+1, n+1];

            // Base Case: No factories left, dist is infinite.
            for (int i = 0; i < m; i++) dp[i, n] = long.MaxValue;

            // Process Factory
            for(int j=n-1; j>=0; j--)
            {
                long dist = 0;
                LinkedList<(int pos, long val)> list = new LinkedList<(int pos, long val)>();
                list.AddLast((m, 0));

                for (int i=m-1; i>=0; i--)
                {
                    dist += Math.Abs((long)robot[i] - factories[j][0]);

                    while (list.Count > 0 && list.First!.Value.pos > i + factories[j][1]) list.RemoveFirst();

                    while (list.Count > 0 && list.Last!.Value.val >= dp[i, j + 1] - dist) list.RemoveLast();

                    list.AddLast((i, dp[i, j + 1] - dist));
                    dp[i, j] = list.First!.Value.val + dist;
                }
            }
            return dp[0,0];
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MinimumTotalDistance(Globals.robot, Globals.factories));
            return;
        }
    }
}