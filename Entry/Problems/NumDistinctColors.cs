// LeetCode 3160
using System;
using System.Collections.Generic;

namespace _3160
{
    public static class Globals
    {
        public static int limit = 4;
        public static int[][] queries = new int[4][]
        {
            new int[2] { 1, 4 }, new int[2] { 2, 5 }, new int[2] { 1, 3 }, new int[2] { 3, 4 }
        };
    }
    public class Program
    {
        public int[] QueryResults(int limit, int[][] queries)
        {
            List<int> numColors = new List<int>();
            int[] results = new int[queries.GetLength(0)];
            
            for (int i=0; i<queries.GetLength(0); i++)
            {
                if (numColors.Contains(queries[i][1]))
                {
                    results[i] = results[i - 1];
                    continue;
                }
                numColors.Add(queries[i][1]);
                results[i] = numColors.Count;
            }
            return results;
        }

        public static void prettyPrint(int[] results)
        {
            Console.Write("{ ");
            foreach (int result in results)
                Console.Write($"{result} ");
            Console.WriteLine("}");
            return;
        }
    }
}