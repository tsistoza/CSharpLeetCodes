// LeetCode 200
using System;
using System.Collections.Generic;

public static class Globals
{
    public static char[,] islands =
    {
        { '1', '1', '1', '1', '0' },
        { '1', '1', '0', '1', '0' },
        { '1', '1', '0', '0', '0' },
        { '0', '0', '0', '0', '0' }
    };
}

namespace Solution
{
    public class Program
    {
        public int numIslands(char[,] grid)
        {
            List<Tuple<int,int>> infected = new List<Tuple<int,int>>();
            for(int i=0; i<grid.GetLength(0); i++)
                for (int j=0; j<grid.GetLength(1); j++)
                    if (grid[i,j] == '1') infected.Add(new Tuple<int,int>(i,j));

            // Find all the islands
            char[,] copyGrid = grid;
            List<List<Tuple<int, int>>> islands = new List<List<Tuple<int, int>>>();
            foreach (Tuple<int,int> tuple in infected)
            {
                bool alreadyCounted = false;
                foreach (List<Tuple<int,int>> region in islands)
                {
                    if (region.Contains(tuple))
                    {
                        alreadyCounted = true;
                        break;
                    }
                }
                   
                if (alreadyCounted)
                {
                    alreadyCounted = false;
                    continue;
                }
                List<Tuple<int, int>> island = new List<Tuple<int, int>>();
                findAllIslandsBFS(copyGrid, tuple.Item1, tuple.Item2, island);
                islands.Add(island);
            }
            return islands.Count;
        }


        public void findAllIslandsBFS(char[,] grid, int i, int j, List<Tuple<int,int>> island)
        {
            if (i < 0 || i >= grid.GetLength(0) || j < 0 || j >= grid.GetLength(1)) return;
            if (grid[i, j] == '0' || grid[i, j] == '-') return;
            if (grid[i, j] == '1') island.Add(new Tuple<int, int>(i, j));

            grid[i, j] = '-';
            findAllIslandsBFS(grid, i + 1, j, island);
            findAllIslandsBFS(grid, i, j + 1, island);
            findAllIslandsBFS(grid, i - 1, j, island);
            findAllIslandsBFS(grid, i, j - 1, island);
            return;
        }

        public static void Main()
        {   Program obj = new Program();
            Console.WriteLine(obj.numIslands(Globals.islands));
            return;
        }
    }
}