// LeetCode 2940
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] heights = { 6, 4, 8, 5, 2, 7 };
    public static int[][] queries = new int[5][]
    {
        new int[2] { 0, 1 },
        new int[2] { 0, 3 },
        new int[2] { 2, 4 },
        new int[2] { 3, 4 },
        new int[2] { 2, 2 }
    };

    public static int[] heights1 = { 5, 3, 8, 2, 6, 1, 4, 6 };
    public static int[][] queries1 = new int[5][]
    {
        new int[2] { 0, 7 },
        new int[2] { 3, 5 },
        new int[2] { 5, 2 },
        new int[2] { 3, 0 },
        new int[2] { 1, 6 }
    };
}

namespace Solution
{
    public class Program
    {
        public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
        {
            List<int> result = new List<int>();
            for (int i=0; i<queries.GetLength(0); i++)
            {
                int index = -1;
                int max = (queries[i][0] < queries[i][1]) ? queries[i][1] : queries[i][0];
                for (int j = max; j<heights.GetLength(0); j++)
                {
                    if (heights[queries[i][0]] <= heights[j] && heights[queries[i][1]] <= heights[j])
                    {
                        index = j;
                        break;
                    }
                }
                result.Add(index);
            }
            return result.ToArray();
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach (int i in obj.LeftmostBuildingQueries(Globals.heights, Globals.queries))
                Console.Write($"{i} ");
            Console.WriteLine();

            foreach (int i in obj.LeftmostBuildingQueries(Globals.heights1, Globals.queries1))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}