// LeetCode 2493
using System;
using System.Collections.Generic;

namespace _2493
{
    public static class Globals
    {
        public static int n = 6;
        public static int[][] edges = new int[6][]
        {
            new int[2] { 1, 2 },
            new int[2] { 1, 4 },
            new int[2] { 1, 5 },
            new int[2] { 2, 6 },
            new int[2] { 2, 3 },
            new int[2] { 4, 6 }
        };

        public static int n1 = 3;
        public static int[][] edges1 = new int[3][]
        {
            new int[2] { 1, 2 },
            new int[2] { 2, 3 },
            new int[2] { 3, 1 }
        };
    }

    public class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        public Pair(T1 _first, T2 _second)
        {
            First = _first; Second = _second;
        }
    }
    public class Program
    {
        public int bfs(int start, Dictionary<int,List<int>> adjList)
        {
            Dictionary<int,int> depthCheck = new Dictionary<int,int>();
            int depth = 1;
            Queue<Pair<int,int>> bfsQ = new Queue<Pair<int,int>>();
            bfsQ.Enqueue(new Pair<int,int>(start, depth));

            while (bfsQ.Count > 0)
            {
                int current = bfsQ.First().First;
                int currDepth = bfsQ.First().Second;
                bfsQ.Dequeue();
                depth = currDepth;
                if (depthCheck.ContainsKey(current)) continue;

                depthCheck.Add(current, currDepth);


                foreach (int i in adjList[current])
                {
                    if (!depthCheck.ContainsKey(i))
                    {
                        bfsQ.Enqueue(new Pair<int, int>(i, currDepth + 1));
                        continue;
                    }

                    if (currDepth == 1) continue;
                    if (currDepth - 1 != depthCheck[i]) return -1;
                }
            }

            return depth;
        }
        public int MagnificentSets(int n, int[][] edges)
        {
            // Init Adj List
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                if (adjList.ContainsKey(edges[i][0])) adjList[edges[i][0]].Add(edges[i][1]);
                else adjList.Add(edges[i][0], new List<int>() { edges[i][1] });
                if (adjList.ContainsKey(edges[i][1])) adjList[edges[i][1]].Add(edges[i][0]);
                else adjList.Add(edges[i][1], new List<int>() { edges[i][0] });
            }

            // BFS needs to begin at a leaf node
            foreach (int i in adjList.Keys)
                if (adjList[i].Count == 1) return bfs(i, adjList);
            return -1;
        }
    }
}