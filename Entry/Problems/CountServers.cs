// LeetCode 1267
using System;
using System.Collections.Generic;

namespace _1267
{
    public static class Globals
    {
        public static int[][] grid = new int[2][]
        {
            new int[2] { 1, 0 }, new int[2] { 1, 1 }
        };
    }
    public class Program
    {
        public int CountServers(int[][] grid)
        {
            int count = 0;
            List<Tuple<int,int>> servers = new List<Tuple<int,int>>();
            Dictionary<int,int> rowCount = new Dictionary<int,int>();
            Dictionary<int,int> colCount = new Dictionary<int,int>();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0) continue;
                    servers.Add(new Tuple<int,int>(i, j));
                    if (rowCount.ContainsKey(i)) rowCount[i]++;
                    else rowCount.Add(i, 1);
                    if (colCount.ContainsKey(j)) colCount[j]++;
                    else colCount.Add(j, 1);
                }
            }

            foreach (Tuple<int,int> tuple in servers)
                if (rowCount[tuple.Item1] > 1 || colCount[tuple.Item2] > 1) count++;
            return count;
        }
    }
}