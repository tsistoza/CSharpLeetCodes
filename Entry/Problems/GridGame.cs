// LeetCode 2017
using System;
using System.Collections.Generic;

namespace _2017
{
    public static class Globals
    {
        public static int[,] grid = { { 2, 5, 4 }, { 1, 5, 1 } };
    }
    public class Program
    {
        public long GridGame(int[,] grid)
        {
            // Sums are for robot2
            long firstRowSum = 0;
            long secondRowSum = 0;
            long minimumSumRobot2 = int.MaxValue;
            for (int i = 0; i < grid.GetLength(1); i++) firstRowSum += grid[0, i];
            
            for (int i = 0; i<grid.GetLength(1); i++) // Ignore Robot1 Path
            {
                firstRowSum -= grid[0, i]; // Robot2 path 1

                // Maximize R2 score, Path1 or Path2
                long maxR2 = Math.Max(firstRowSum, secondRowSum);
                // Maximize R1 score, to get the maximum for R2.
                minimumSumRobot2 = Math.Min(minimumSumRobot2, maxR2);

                secondRowSum += grid[1, i]; // Robot2 path 2
            }

            return minimumSumRobot2;
        }
    }
}