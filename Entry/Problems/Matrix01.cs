// LeetCode 542
using System;
using System.Collections.Generic;

namespace _542
{
    public static class Globals
    {
        public static int[,] mat = {{0, 0, 0}, {0, 1, 0}, {0, 0, 0}};
    }

    public class Program
    {
        private void bfs(ref int[,] dp, ref int[,] mat, int m, int n)
        {
            HashSet<(int,int)> vis = new HashSet<(int,int)> ();
            PriorityQueue<(int,int), int> bfsQ = new PriorityQueue<(int,int), int>();
            bfsQ.Enqueue((0, 0), mat[0, 0]);
            while (bfsQ.Count > 0)
            {
                (int x, int y) = bfsQ.Dequeue();
                if (vis.Contains((x, y))) continue;
                vis.Add((x, y));

                int[] dirX = { -1, 0, 1, 0 };
                int[] dirY = { 0, -1, 0, 1 };

                if (mat[x, y] == 0) dp[x, y] = 0;
                else
                {
                    for (int i=0; i<4; i++)
                    {
                        int newX = x + dirX[i];
                        int newY = y + dirY[i];

                        if (newX < 0 || newX >= m || newY < 0 || newY >= m) continue;
                        if (dp[newX, newY] == int.MaxValue) continue;

                        dp[x, y] = Math.Min(dp[x, y], dp[newX, newY] + 1);
                    }
                }

                for (int i=2; i<4; i++)
                {
                    int newX = x + dirX[i];
                    int newY = y + dirY[i];

                    if (vis.Contains((newX, newY))) continue;
                    if (newX >= m || newY >= n) continue;
                    bfsQ.Enqueue((newX, newY), mat[newX, newY]);
                }
            }
            return;
        }

        public static void PrettyPrint(int[,] dp)
        {
            Console.Write("{ ");
            for (int i=0; i<dp.GetLength(0); i++)
            {
                Console.Write("{ ");
                for (int j=0; j<dp.GetLength(1); j++)
                {
                    if (j == dp.GetLength(1)-1) Console.Write($"{dp[i, j]} ");
                    else Console.Write($"{dp[i, j]}, ");
                }
                if (i == dp.GetLength(0) - 1) Console.Write("} ");
                else Console.Write("}, ");
            }
            Console.WriteLine("} ");
            return;
        }

        private void ResetArray(ref int[,] dp)
        {
            for (int i=0; i<dp.GetLength(0); i++)
                for (int j=0; j<dp.GetLength(1); j++)
                    dp[i, j] = int.MaxValue;
        }
        public int[,] UpdateMatrix(int[,] mat)
        {
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);
            int[,] dp = new int[m, n];
            ResetArray(ref dp);
            bfs(ref dp, ref mat, m, n);
            return dp;
        }
    }
}
