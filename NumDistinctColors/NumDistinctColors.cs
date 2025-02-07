// LeetCode 3160
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int limit = 4;
    public static int[][] queries = new int[4][]
    {
        new int[2] { 1, 4 }, new int[2] { 2, 5 }, new int[2] { 1, 3 }, new int[2] { 3, 4 }
    };

    public static int[][] queries1 = new int[5][]
    {
        new int[2] { 0, 1  }, new int[2] { 1, 2 }, new int[2] { 2, 2 }, new int[2] { 3, 4 }, new int[2] { 4, 5 }
    };
}

namespace Solution
{
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

        public static void Main()
        {
            Program obj = new Program();
            prettyPrint(obj.QueryResults(Globals.limit, Globals.queries));
            prettyPrint(obj.QueryResults(Globals.limit, Globals.queries1));
            return;
        }
    }
}