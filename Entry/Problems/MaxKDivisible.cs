// LeetCode 2872
using System;
using System.Collections.Generic;

namespace _2872
{
    public static class Globals
    {
        public static int n = 5;
        public static int k = 6;
        public static int[][] edges = new int[4][]
        {
            new int[2] { 0, 2 },
            new int[2] { 1, 2 },
            new int[2] { 1, 3 },
            new int[2] { 2, 4 }
        };
        public static int[] values = { 1, 8, 1, 4, 4 };
    }
    public class Program
    {
        public int dfs(ref int componentCount, int currentNode, int parentNode, Dictionary<int, List<int>> adjList, int[] values, int k)
        {
            int sum = 0;
            
            foreach (int neighborNode in adjList[currentNode])
            {
                if (neighborNode != parentNode)
                {
                    sum += dfs(ref componentCount, neighborNode, currentNode, adjList, values, k);
                    sum %= k;
                }
            }

            sum += values[currentNode];
            sum %= k;
            if (sum == 0) componentCount++;

            return sum;
        }
        public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
        {
            // Populate adj list
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            for (int i=0; i<edges.GetLength(0); i++)
            {
                if (adjList.ContainsKey(edges[i][0])) adjList[edges[i][0]].Add(edges[i][1]);
                else adjList.Add(edges[i][0], new List<int>() { edges[i][1] });
                if (adjList.ContainsKey(edges[i][1])) adjList[edges[i][1]].Add(edges[i][0]);
                else adjList.Add(edges[i][1], new List<int>() { edges[i][0] });
            }

            int componentCount = 0;
            dfs(ref componentCount, 0, -1, adjList, values, k);

            return componentCount;
        }
    }
}