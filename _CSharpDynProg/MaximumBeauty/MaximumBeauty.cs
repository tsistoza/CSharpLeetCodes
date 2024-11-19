// LeetCode 2070
using System;
using System.Collections.Generic;

public static class Globals
{
    public static readonly List<List<int>> items = new List<List<int>>() { new List<int>() { 1, 2 },
                                                                           new List<int>() { 3, 2 },
                                                                           new List<int>() { 2, 4 },
                                                                           new List<int>() { 5, 6 },
                                                                           new List<int>() { 3, 5 } };
    public static readonly List<int> queries = new List<int>() { 1, 2, 3, 4, 5, 6 };

    public static readonly List<List<int>> items1 = new List<List<int>>() { new List<int>() { 1, 2 },
                                                                            new List<int>() { 1, 2 },
                                                                            new List<int>() { 1, 3 },
                                                                            new List<int>() { 1, 4 }, };
    public static readonly List<int> queries1 = new List<int>() { 1 };
}

namespace Solution
{
    public class Program
    {
        public static IEnumerable<int> maximumBeauty(List<List<int>> items, List<int> queries)
        {
            int[] result = new int[queries.Count];
            Array.Fill<int>(result, 0);
            for (int queryIndex=0; queryIndex<queries.Count; queryIndex++)
                for (int i = 0; i < items.Count; i++)
                    if (items[i][0] <= queries[queryIndex] && result[queryIndex] < items[i][1])
                        result[queryIndex] = items[i][1];
            return result;
        }
        public static void Main(string[] args)
        {
            // Test Case 1
            Console.Write("Max Beauty for each query: ");
            foreach (int maxBeauty in maximumBeauty(Globals.items, Globals.queries))
                Console.Write($"{maxBeauty} ");
            Console.WriteLine();

            // Test Case 2
            Console.Write("Max Beauty for each query: ");
            foreach (int maxBeauty in maximumBeauty(Globals.items1, Globals.queries1))
                Console.Write($"{maxBeauty} ");
            Console.WriteLine();
            return;
        }
    }
}