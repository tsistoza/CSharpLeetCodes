// LeetCode 3619
using System;
using System.Collections.Generic;

namespace _3619
{
    public static class Globals
    {
        public static int[][] grid = new int[5][]
        {
            new int[5] { 0, 2, 1, 0, 0 },
            new int[5] { 0, 5, 0, 0, 5 },
            new int[5] { 0, 0, 1, 0, 0 },
            new int[5] { 0, 1, 4, 7, 0 },
            new int[5] { 0, 2, 0, 0, 8 }
        };
        public static int k = 5;
    }
    public class Program
    {
        private int dfs(bool[,] vis, int[][] grid, int x, int y, int k)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length) return 0;
            if (vis[x, y] || grid[x][y] == 0) return 0;
            vis[x, y] = true;
            int val = grid[x][y];
            val = ((val + dfs(vis, grid, x + 1, y, k)) % k);
            val = ((val + dfs(vis, grid, x - 1, y, k)) % k);
            val = ((val + dfs(vis, grid, x, y + 1, k)) % k);
            val = ((val + dfs(vis, grid, x, y - 1, k)) % k);
            return val;
        }

        public int CountIslands(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] vis = new bool[m, n];
            int numIslands = 0;
            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (grid[i][j] == 0 || vis[i, j]) continue;
                    int sum = dfs(vis, grid, i, j, k);
                    if (sum % k == 0) numIslands++;
                }
            }

            return numIslands;
        }
    }
}
