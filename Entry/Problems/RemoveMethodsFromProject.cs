// LeetCode 3310
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace _3310
{
    public static class Globals
    {
        public static int n = 3;
        public static int k = 2;
        public static int[][] invocations = new int[2][]
        {
            new int[] { 1, 0 },
            new int[] { 2, 0 }
        };
    }
    public class Program
    {
        private static void PrettyPrint(List<int> result)
        {
            Console.Write("{ ");
            foreach (int i in result) Console.Write($"{i} ");
            Console.WriteLine("} \n\n");
            return;
        }

        private void dfs_suspicious(ref List<int>[] adjList, ref HashSet<int> suspicious, int node)
        {
            if (!suspicious.Contains(node)) suspicious.Add(node);
            else return;

            if (adjList[node].Count == 0) return;

            foreach (int nextNode in adjList[node])
                dfs_suspicious(ref adjList, ref suspicious, nextNode);
            return;
        }

        // we are going to use bfs to find a node that is not in the suspicious set, if a node is found, then the set is no longer suspicious
        private void bfs_nonsuspicious(ref List<int>[] revAdjList, ref HashSet<int> suspicious)
        {
            Queue<int> bfsQ = new Queue<int>();
            HashSet<int> visited = new HashSet<int>(suspicious);

            foreach (int suspiciousNode in suspicious)
            {
                if (revAdjList[suspiciousNode].Count == 0) continue;
                foreach (int nextNode in revAdjList[suspiciousNode])
                    bfsQ.Enqueue(nextNode);
            }
            
            while (bfsQ.Count > 0)
            {
                int currNode = bfsQ.Dequeue();

                if (visited.Contains(currNode)) continue;
                if (!suspicious.Contains(currNode))
                {
                    suspicious.Clear();
                    bfsQ.Clear();
                    return;
                }


                foreach (int nextNode in revAdjList[currNode])
                    bfsQ.Enqueue(nextNode);
            }

            return;
        }

        public List<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            List<int>[] adjList = new List<int>[n];
            List<int>[] revAdjList = new List<int>[n];
            for (int i=0; i<n; i++)
            {
                adjList[i] = new List<int>();
                revAdjList[i] = new List<int>();
            }

            for (int i = 0; i < invocations.Length; i++)
            {
                int start = invocations[i][0], end = invocations[i][1];

                adjList[start].Add(end);
                revAdjList[end].Add(start);
            }

            HashSet<int> suspicious = new HashSet<int>();
            dfs_suspicious(ref adjList, ref suspicious, k); // WE DO NOT CARE ABOUT ANY SETS OTHER THAN SUSPICIOUS SET
            bfs_nonsuspicious(ref revAdjList, ref suspicious); // Find remaining nodes in set, if found, suspicious set is no longer suspicious

            List<int> result = new List<int>();
            for (int i=0; i<n; i++)
            {
                if (suspicious.Contains(i)) continue;
                result.Add(i);
            }

            PrettyPrint(result);
            return result;
        }
    }
}
