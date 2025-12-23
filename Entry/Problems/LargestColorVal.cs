// LeetCode 1857
using System;
using System.Collections.Generic;

namespace _1857
{
    public static class Globals
    {
        public static string colors = "abaca";
        public static int[,] edges = {  };
    }
    public class Compare : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            if (x < y) return 1;
            if (x > y) return -1;
            return 0;
        }
    }
    public class Program
    {
        public int LargestPathValue(string colors, int[,] edges)
        {
            int count = 0;
            Dictionary<int,List<int>> dict = new Dictionary<int,List<int>>();

            if (edges.Length == 0) return 1;
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                if (!dict.TryAdd(edges[i,0], new List<int> { edges[i, 1] }))
                    dict[edges[i, 0]].Add(edges[i, 1]);
            }

            List<int> nodes = new List<int>(dict.Keys);
            List<List<int>> dp = new List<List<int>>(Enumerable.Repeat(new List<int>(Enumerable.Repeat(0, colors.Length)), colors.Length+1));
            HashSet<int> visited = new HashSet<int>();
            Compare cmp = new Compare();
            PriorityQueue<(int,int), int> queue = new PriorityQueue<(int,int), int>(cmp);
            queue.Enqueue((nodes[0], -1), 0); // Start from 0, with no parent (-1)
            nodes.RemoveAt(0);
            while (queue.Count > 0)
            {
                (int, int) node;
                int priority;
                queue.TryDequeue(out node, out priority);
                char color = colors[node.Item1];

                Console.WriteLine($"current = {node.Item1}, parent = {node.Item2}");
                if (!visited.Contains(node.Item1)) // Cycle Check
                    visited.Add(node.Item1);
                else return -1;

                if (node.Item2 != -1) {
                    dp[node.Item1] = dp[node.Item2];
                    dp[node.Item1][color - 'a'] = dp[node.Item2][color - 'a'] + 1;
                } else
                    dp[node.Item1][color - 'a'] += 1;

                count = Math.Max(count, dp[node.Item1][color - 'a']);

                if (!dict.ContainsKey(node.Item1))
                {
                    if (nodes.Count <= 0) continue;
                    if (queue.Count > 0) continue;
                    queue.Enqueue((nodes[0], -1), 0);
                    nodes.RemoveAt(0);
                    continue;
                }

                foreach (int adj in dict[node.Item1])
                {
                    queue.Enqueue((adj, node.Item1), priority+1); // enqueue its adjacent, while heeping track of the parent, prioritize depth, over breadth
                    nodes.Remove(adj);
                }
            }
            
            return count;
        }
    }
}