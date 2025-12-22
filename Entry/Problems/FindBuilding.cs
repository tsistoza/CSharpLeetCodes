// LeetCode 2940
using System;
using System.Collections.Generic;

namespace _2940
{
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
    }
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
    }
}