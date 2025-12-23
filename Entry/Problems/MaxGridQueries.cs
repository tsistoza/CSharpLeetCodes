// LeetCode 2503
using System;
using System.Collections.Generic;

namespace _2503
{
    public static class Globals
    {
        public static int[,] grid = { { 5, 2, 1 }, { 1, 1, 2 } };
        public static int[] queries = { 3 };
    }
    public class Program
    {
        public static void prettyPrint(int[] answer)
        {
            Console.Write("{ ");
            foreach (int i in answer)
                Console.Write($"{i}, ");
            Console.WriteLine("}");
            return;
        }
        private int bfs(int[,] grid, int query)
        {
            int ans = 0;
            HashSet<Tuple<int,int>> vis = new HashSet<Tuple<int,int>>();
            Queue<Tuple<int,int>> bfsQ = new Queue<Tuple<int,int>>();
            bfsQ.Enqueue(new Tuple<int, int>(0, 0));
            while (bfsQ.Count > 0)
            {
                Tuple<int,int> currPos = bfsQ.Dequeue();

                if (vis.Contains(currPos)) continue;
                vis.Add(currPos);
                
                if (grid[currPos.Item1, currPos.Item2] < query) ans++;
                else continue;

                int[] dirX = { -1, 0, 1, 0 };
                int[] dirY = { 0, -1, 0, 1 };
                for (int i=0; i<4; i++)
                {
                    Tuple<int, int> newPos = new Tuple<int, int>(currPos.Item1 + dirX[i], currPos.Item2 + dirY[i]);
                    if (newPos.Item1 < 0 || newPos.Item1 >= grid.GetLength(0) || newPos.Item2 < 0 || newPos.Item2 >= grid.GetLength(1)) continue;
                    if (vis.Contains(newPos)) continue;
                    bfsQ.Enqueue(newPos);
                }
            }
            return ans;
        }
        public int[] MaxPoints(int[,] grid, int[] queries)
        {
            int[] answer = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                answer[i] = bfs(grid, queries[i]);
            return answer;
        }
    }
}