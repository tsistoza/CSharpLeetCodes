using System;
using System.Runtime.Intrinsics.Arm;


public static class Globals
{
    public static int[,] cost = new int[3, 3] { { 1, 2, 3 }, { 4, 8, 2 }, { 1, 5, 3 } };
    public static int xStart = 0;
    public static int yStart = 0;
}

namespace Solution
{
    public class Program
    {
        public static int minCost(int[,] cost)
        {
            int[,] dp = new int[cost.GetLength(0), cost.GetLength(1)];
            // Base Case
            dp[0,0] = cost[0, 0];

            for (int i = 1; i < cost.GetLength(0); i++) dp[i, 0] = dp[i - 1, 0] + cost[i, 0];

            for (int i = 1; i < cost.GetLength(1); i++) dp[0, i] = dp[0, i - 1] + cost[0, i];

            for (int i = 1; i<cost.GetLength(0); i++)
                for (int j = 1; j< cost.GetLength(1); j++)
                    dp[i, j] = cost[i, j] + min(dp[i - 1, j - 1], dp[i - 1, j], dp[i, j - 1]);


            return dp[cost.GetLength(0)-1, cost.GetLength(1)-1];
        }

        private static int min(int int1, int int2, int int3)
        {
            if (int1 < int2 && int1 < int3) return int1;
            else if (int2 < int1 && int2 < int3) return int2;
            else if (int3 < int1 && int3 < int2) return int3;
            if (int1 == int2) return int1;
            if (int2 == int3) return int2;
            if (int1 == int3) return int1;
            return 0;
        }

        public static void Main()
        {
            Console.WriteLine(minCost(Globals.cost));
            return;
        }
    }
}