// Leetcode 1582
using System;
using System.Collections.Generic;

namespace _1582
{
    public static class Globals
    {
        public static int[,] mat = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
    }

    public class Program
    {
        public int NumSpecial(int[,] mat)
        {
            Dictionary<int, int> rowCount = new Dictionary<int, int>();
            Dictionary<int, int> columnCount = new Dictionary<int, int>();
            List<(int,int)> indexes = new List<(int,int)> ();

            for (int i=0; i<mat.GetLength(0); i++)
            {
                for (int j=0; j<mat.GetLength(1); j++)
                {
                    if (mat[i, j] == 0) continue;
                    indexes.Add((i, j));
                    if (!rowCount.TryAdd(i, 1)) rowCount[i]++;
                    if (!columnCount.TryAdd(j, 1)) columnCount[j]++;
                }
            }

            int count = 0;
            foreach ((int i, int j) in indexes)
            {
                if (rowCount[i] > 1) continue;
                if (columnCount[j] > 1) continue;
                ++count;
            }

            return count;
        }
    }
}
