// LeetCode 3650
using System;
using System.Collections.Generic;
using System.Text;

namespace _3650
{
    public static class Globals
    {
        public static int n = 4;
        public static int[,] edges = { { 0, 2, 1 }, { 2, 1, 1}, { 1, 3, 1}, { 2, 3, 3 } };
    }

    public class Program
    {
        public int MinCost(int n, int[,] edges)
        {
            Dictionary<int, List<(int,int)>> adjList = new Dictionary<int, List<(int,int)>>();
            Dictionary<int, List<(int, int)>> inList = new Dictionary<int, List<(int,int)>>();
            for (int i=0; i<edges.GetLength(0); i++)
            {
                if (!adjList.TryAdd(edges[i, 0], new List<(int,int)>() { (edges[i, 1], edges[i, 2]) }))
                    adjList[edges[i, 0]].Add((edges[i, 1], edges[i, 2]));
                if (!inList.TryAdd(edges[i, 1], new List<(int,int)>() { (edges[i, 0], edges[i, 2]) }))
                    inList[edges[i, 1]].Add((edges[i, 0], edges[i, 2]));
            }


            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            queue.Enqueue(0, 0);

            while (queue.Count > 0)
            {
                int node, cost;
                queue.TryPeek(out node, out cost);

                if (node == n - 1) return cost;

                if (adjList.ContainsKey(node))
                {
                    for (int i = 0; i < adjList[node].Count; i++)
                        queue.Enqueue(adjList[node][i].Item1, cost + adjList[node][i].Item2);
                }
                
                if (inList.ContainsKey(node)) // Flip in routes
                {
                    for (int i = 0; i < inList[node].Count; i++)
                        queue.Enqueue(inList[node][i].Item1, cost + (2 * inList[node][i].Item2));
                }

                queue.Dequeue();
            }
            return -1;
        }
    }
}
