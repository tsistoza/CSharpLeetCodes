// LeetCode 2379
using System;
using System.Collections.Generic;



namespace _2379
{
    public static class Globals
    {
        public static string blocks = "WBWBBBW";
        public static int k = 2;
    }
    public class Program
    {
        public int minimumRecolors(string blocks, int k)
        {
            int differences = int.MaxValue;
            for (int i = k-1; i < blocks.Length; i++)
            {
                int currDifferences = 0;
                for (int j = i - k + 1; j <= i; j++)
                {
                    if (differences != int.MaxValue) break;
                    if (blocks[j] == 'W') currDifferences++;
                }

                if (differences != int.MaxValue)
                {
                    currDifferences = differences;
                    if (blocks[i] == 'W') currDifferences++;
                    if (blocks[i - k] == 'W') currDifferences--;
                }

                differences = Math.Min(differences, currDifferences);
                if (differences == 0) return differences;
            }

            return differences;
        }
    }
}