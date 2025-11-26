// LeetCode 2435
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

public static class Globals
{
    public static int [,] grid = { { 7, 3, 4, 9 }, { 2, 3, 6, 2 }, { 2, 3, 7, 0 } };
    public static int k = 1;
} 

namespace Solution
{
    public class Program
    {
        private void dfs(ref int[,] grid, ref int[,,] dp, (int x, int y) index, int mod, int sum)
        {
            int rem = (sum + grid[index.x, index.y]) % mod;
            dp[index.x, index.y, rem]++;

            int[] dx = { 1, 0 };
            int[] dy = { 0, 1 };

            for (int i=0; i<dx.Length; i++)
            {
                int newX = index.x + dx[i];
                int newY = index.y + dy[i];

                if (newX >= grid.GetLength(0) || newY >= grid.GetLength(1)) continue;
                dfs(ref grid, ref dp, (newX, newY), mod, sum + grid[index.x, index.y]);
            }
        }
        public int NumberOfPaths(int[,] grid, int k)
        {
            int m = grid.GetLength(0), n = grid.GetLength(1);
            HashSet<(int,int)> vis = new HashSet<(int,int)> ();
            int[,,] dp = new int[m, n, k];
            dfs(ref grid, ref dp, (0, 0), k, 0);
            return dp[m-1, n-1, 0];
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.NumberOfPaths(Globals.grid, Globals.k));
            return;
        }
    }
}