// LeetCode 2577
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] grid = new int[3, 4]
    {
        { 0, 1, 3, 2 },
        { 5, 1, 2, 5 },
        { 4, 3, 8, 6 }
    };

    public static int[,] grid1 = new int[3, 3]
    {
        { 0, 2, 4 },
        { 3, 2, 1 },
        { 1, 0, 4 }
    };
}

namespace Solution
{
    public class Program
    {
        private List<Tuple<int, int>> direction;
        public int MinimumTime(int[,] grid)
        {
            int[,] minTime = new int[grid.GetLength(0), grid.GetLength(1)];
            for (int i = 0; i<grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    minTime[i, j] = int.MaxValue;
            minTime[0, 0] = 0;
            Queue<Tuple<int,int,int>> bfsQ = new Queue<Tuple<int,int,int>>();
            bfsQ.Enqueue(new Tuple<int,int,int>(0, 0, 0));
            while(bfsQ.Count > 0)
            {
                Tuple<int,int,int> index = bfsQ.Dequeue();
                // Since we already found a path from (0,0) to (m-1,n-1) just break, this will be the path with minimumTime
                if (index.Item1 == grid.GetLength(0) - 1 && index.Item2 == grid.GetLength(1) - 1) break;
                BFS(grid, minTime, bfsQ, index);

            }
            if (minTime[grid.GetLength(0) - 1, grid.GetLength(1) - 1] == int.MaxValue) return -1;
            return minTime[grid.GetLength(0)-1,grid.GetLength(1)-1];
        }

        public void BFS(int[,] grid, int[,] minTime, Queue<Tuple<int,int,int>> bfsQ, Tuple<int,int,int> index)
        {
            int i = index.Item1, j = index.Item2, time = index.Item3;
            foreach (Tuple<int,int> dir in direction)
            {
                int newX = i + dir.Item1;
                int newY = j + dir.Item2;
                if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
                {
                    int newTime = time;
                    if (index.Item3 < grid[newX,newY]-1) continue; // if the currentTime is less than (time on grid-1), this is no longer traversable
                    newTime++;
                    if (newTime < minTime[newX, newY]) // Save the minimum time to get to this position
                        minTime[newX, newY] = newTime;
                    bfsQ.Enqueue(new Tuple<int, int, int>(newX, newY, newTime));
                }
            }
            return;
        }

        public Program()
        {
            this.direction = new List<Tuple<int, int>>()
            {
                new Tuple<int,int>(1, 0),
                new Tuple<int,int>(-1, 0),
                new Tuple<int,int>(0, 1),
                new Tuple<int,int>(0, -1)
            };
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MinimumTime(Globals.grid));
            Console.WriteLine(obj.MinimumTime(Globals.grid1));
            return;
        }
    }
}