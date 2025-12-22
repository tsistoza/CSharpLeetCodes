// LeetCode 1368
using System;
using System.Collections.Generic;

namespace _1368
{
    public static class Globals
    {
        public static int[,] grid = new int[4, 4]
        {
            { 1, 1, 1, 1 },
            { 2, 2, 2, 2 },
            { 1, 1, 1, 1 },
            { 2, 2, 2, 2 }
        };
    }
    public class Pair<T1, T2>
    {
        public T1 x { get; set; }
        public T2 y { get; set; }

        public Pair(T1 _x, T2 _y)
        {
            this.x = _x; this.y = _y;
        }
    }
    public class Program
    {
        private List<int> getPossiblePaths(Tuple<int, int> index, List<Tuple<int, int>> visited, int[,] grid)
        {
            // paths[0] -> Right
            // paths[1] -> Left etc.....
            // paths[i] = {-1, 0, 1} -1 means not possible, 0 means no cost, 1 means cost
            if (index.Item1 == 0 && index.Item2 == 0)
            {
                int right = 0;
                int down = 0;
                if (grid[index.Item1, index.Item2] == 1) down = 1;
                else right = 1;

                return new List<int>() { right, down, };
            }

            List<int> paths = new List<int>(4);
            for (int i = 0; i < paths.Capacity; i++) paths.Add(1);
            paths[(grid[index.Item1, index.Item2]) - 1] = 0;

            // Bounds Checker
            if (index.Item2 + 1 > grid.GetLength(1) - 1) paths[0] = -1;
            if (index.Item2 - 1 < 0) paths[1] = -1;

            if (index.Item1 + 1 > grid.GetLength(0) - 1) paths[2] = -1;
            if (index.Item1 - 1 < 0) paths[3] = -1;

            // Visited
            if (visited.Contains(new Tuple<int, int>(index.Item1, index.Item2 + 1))) paths[0] = -1;
            if (visited.Contains(new Tuple<int, int>(index.Item1, index.Item2 - 1))) paths[1] = -1;
            if (visited.Contains(new Tuple<int, int>(index.Item1 + 1, index.Item2))) paths[2] = -1;
            if (visited.Contains(new Tuple<int, int>(index.Item1 - 1, index.Item2))) paths[3] = -1;

            return paths;
        }
        private void dfs(Tuple<int,int> index, List<Tuple<int,int>> visited, int[,] grid, int currCost, ref int minCost)
        {
            //Console.WriteLine($"({index.Item1}, {index.Item2}) -> Parent: ({visited.Last().Item1}, {visited.Last().Item2})");
            visited.Add(index);
            if (index.Item1 == 0 && index.Item2 == 0)
            {
                List<int> start = getPossiblePaths(index, new List<Tuple<int,int>>(visited), grid);
                dfs(new Tuple<int, int>(index.Item1, index.Item2 + 1), new List<Tuple<int,int>>(visited), grid, currCost + start[0], ref minCost);
                dfs(new Tuple<int, int>(index.Item1 + 1, index.Item2), new List<Tuple<int,int>>(visited), grid, currCost + start[1], ref minCost);
                return;
            }

            if (index.Item1 == grid.GetLength(0)-1 && index.Item2 == grid.GetLength(1)-1)
            {
                minCost = (minCost < currCost) ? minCost : currCost;
                return;
            } 

            List<int> paths = getPossiblePaths(index, visited, grid);
            if (paths[0] != -1)
                dfs(new Tuple<int, int>(index.Item1, index.Item2 + 1), new List<Tuple<int,int>>(visited), grid, currCost + paths[0], ref minCost);
            if (paths[1] != -1)
                dfs(new Tuple<int, int>(index.Item1, index.Item2 - 1), new List<Tuple<int,int>>(visited), grid, currCost + paths[1], ref minCost);
            if (paths[2] != -1)
                dfs(new Tuple<int, int>(index.Item1 + 1, index.Item2), new List<Tuple<int,int>>(visited), grid, currCost + paths[2], ref minCost);
            if (paths[3] != -1)
                dfs(new Tuple<int, int>(index.Item1 - 1, index.Item2), new List<Tuple<int,int>>(visited), grid, currCost + paths[3], ref minCost);
            return;
        }
        public int MinCost(int[,] grid)
        {
            int cost = int.MaxValue;
            dfs(new Tuple<int,int>(0, 0), new List<Tuple<int,int>>(), grid, 0, ref cost);
            return cost;
        }
    }
}