// LeetCode 2290
using System;
using System.Collections.Generic;

namespace _2290
{
    public static class Globals
    {
        public static int[][] grid =
        {
            new int[3] { 0, 1, 1 },
            new int[3] { 1, 1, 0 },
            new int[3] { 1, 1, 0 }
        };
    }
    public class Program
    {
        private List<Tuple<int, int>> direction;

        // Regardless of the path, all we care about is getting the minimum number of obstacles. We only need to save, whether or not we hit an obstacle or not
        public int MinimumObstacles(int[][] grid)
        {
            Queue<Tuple<int,int>> bfsQ = new Queue<Tuple<int, int>>();
            int[,] distance = new int[grid.Length, grid[0].Length]; // This will represent the minimum obstacles hit on each cell.
                                                                    // We do not care about, any other paths other than the one with the min obstacles hit
            for (int i=0; i<grid.Length; i++)
                for (int j=0; j < grid[i].Length; j++)
                    distance[i,j] = int.MaxValue;                   // Fill distance with maximum, since we want to find the minimum.

            distance[0, 0] = 0; // There is no obstacle at (0,0)
            bfsQ.Enqueue(new Tuple<int,int>(0,0));
            while(bfsQ.Count > 0)
            {
                Tuple<int,int> index = bfsQ.Dequeue();
                BFS(grid, bfsQ, index, distance);
            }
            return distance[grid.Length-1,grid[0].Length-1];
        }
        
        public void BFS(int[][] grid, Queue<Tuple<int,int>> bfsQ, Tuple<int,int> index, int[,] distance)
        {
            int i = index.Item1, j = index.Item2;
            foreach (Tuple<int,int> dir in direction)
            {
                int newX = i + dir.Item1;
                int newY = j + dir.Item2;
                if (newX >= 0 && newX < grid.Length && newY >=0 && newY < grid[i].Length)
                {
                    int newDist = distance[i, j] + grid[i][j];
                    if (newDist < distance[newX, newY])
                    {
                        distance[newX, newY] = newDist;
                        bfsQ.Enqueue(new Tuple<int, int>(newX, newY));
                    }
                }
            }
            return;
        }

        public Program()
        {
            this.direction = new List<Tuple<int, int>>()
            {
                new Tuple<int,int>(1,0),
                new Tuple<int,int>(-1,0),
                new Tuple<int,int>(0,1),
                new Tuple<int,int>(0,-1)
            };
        }
    }
}