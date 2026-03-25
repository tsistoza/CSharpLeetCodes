// LeetCode 3546
using System;
using System.Collections.Generic;

namespace _3546
{
    public static class Globals
    {
        public static int[,] grid = { { 9, 23, 1814, 17, 62 }, { 129, 24, 2, 113, 263 }, { 1, 472, 6, 872, 43 } };
    }
    public class Program
    {
        private (long, long) SumSectionRow(int partition, ref int[,] grid, ref List<List<int>> rowPrefixSums)
        {
            // Row Partitions
            int rowLength = grid.GetLength(1) - 1;
            long section1 = 0, section2 = 0;

            for (int i=0; i<partition; i++) 
                section1 += rowPrefixSums[i][rowLength];

            for (int i=partition; i < grid.GetLength(0); i++)
                section2 += rowPrefixSums[i][rowLength];

            return (section1, section2);
        }

        private (long, long) SumSectionCol(int partition, ref int[,] grid, ref List<List<int>> rowPrefixSums)
        {
            // Col Partitions
            int rowLength = grid.GetLength(1) - 1;
            long section1 = 0, section2 = 0;

            for (int i=0; i<grid.GetLength(0); i++)
            {
                int sumRowAtPartition = rowPrefixSums[i][partition - 1];
                section1 += sumRowAtPartition;
                section2 += (rowPrefixSums[i][rowLength] - sumRowAtPartition);
            }

            return (section1, section2);
        }

        public bool CanPartitionGrid(int[,] grid)
        {
            List<List<int>> rowPrefixSums = new List<List<int>>();
            for (int i=0; i<grid.GetLength(0); i++)
            {
                rowPrefixSums.Add(new List<int>() { grid[i, 0] });

                for (int j=1; j<grid.GetLength(1); j++)
                {
                    rowPrefixSums[i].Add(rowPrefixSums[i][j - 1] + grid[i, j]);
                }
            }

            // Row Partitions or Horizontal Cuts
            for (int i=1; i<grid.GetLength(0); i++) // @ i=1, we take the sums of rows < i & the sums of rows >= i
            {
                (long section1, long section2) = SumSectionRow(i, ref grid, ref rowPrefixSums);
                Console.WriteLine($"Row Cut @ {i}: section1 = {section1}, section2 = {section2}");
                if (section1 == section2) return true;
            }

            // Col Partitions or Vertical Cuts
            for (int i=1; i<grid.GetLength(1); i++)
            {
                (long section1, long section2) = SumSectionCol(i, ref grid, ref rowPrefixSums);
                Console.WriteLine($"Col Cut @ {i}: section1 = {section1}, section2 = {section2}");
                if (section1 == section2) return true;
            }


            return false;
        }
    }
}
