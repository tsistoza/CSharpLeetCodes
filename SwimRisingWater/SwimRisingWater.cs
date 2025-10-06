// LeetCode 778
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] grid = { { 0, 2 }, { 1, 3 } };
}

namespace Solution
{
    public class Program
    {
        public int SwimInWater(int[,] grid)
        {
            int gridSize = grid.GetLength(0);
            int minTime = int.MaxValue;

            HashSet<(int x, int y, int time)> vis = new HashSet<(int x, int y, int time)> ();
            PriorityQueue<(int x, int y, int time), int> bfsQ = new PriorityQueue<(int x, int y, int time), int>();
            bfsQ.Enqueue((0, 0, 0), grid[0, 0]);

            while (bfsQ.Count > 0)
            {
                (int x, int y, int time) currLocation = bfsQ.Dequeue();
                vis.Add(currLocation);

                if (currLocation.x == gridSize-1 && currLocation.y == gridSize-1)
                {
                    bfsQ.Clear();
                    minTime = currLocation.time;
                    break;
                }

                int[] dirX = { 0, -1, 0, 1 };
                int[] dirY = { -1, 0, 1, 0 };
                for (int i=0; i<4; i++)
                {
                    int newX = dirX[i] + currLocation.x;
                    int newY = dirY[i] + currLocation.y;
                    if (newX < 0 || newX >= gridSize || newY < 0 || newY >= gridSize) continue;

                    int newTime = (grid[newX, newY] <= currLocation.time) ? currLocation.time : grid[newX, newY];
                    (int x, int y, int time) newLocation = (newX, newY, newTime);
                    if (vis.Contains(newLocation)) continue;
                    bfsQ.Enqueue(newLocation, newLocation.time);
                }
            }

            return minTime;
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.SwimInWater(Globals.grid));
            return;
        }
    }
}