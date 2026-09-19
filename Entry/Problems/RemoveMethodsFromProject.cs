// LeetCode 3310
using _1652;
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

        private void bfs_suspicious(ref List<int>[] adjList, ref bool[] bad, int badNode)
        {
            Queue<int> bfsQ = new Queue<int>();

            if (adjList[badNode].Count == 0) return;

            foreach (int node in adjList[badNode]) bfsQ.Enqueue(node);

            while (bfsQ.Count > 0)
            {
                int node = bfsQ.Dequeue();
                if (!bad[node]) bad[node] = true;
                else continue;

                if (adjList[node].Count == 0) continue;
                foreach (int nextNode in adjList[node]) bfsQ.Enqueue(nextNode);
            }
            return;
        }

        public List<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            List<int>[] adjList = new List<int>[n];
            for (int i=0; i<n; i++) adjList[i] = new List<int>();

            for (int i = 0; i < invocations.Length; i++)
            {
                int start = invocations[i][0], end = invocations[i][1];
                adjList[start].Add(end);
            }

            bool[] bad = new bool[n];
            bad[k] = true;
            bfs_suspicious(ref adjList, ref bad, k); // WE DO NOT CARE ABOUT ANY SETS OTHER THAN SUSPICIOUS SET

            for (int i = 0; i < invocations.GetLength(0); i++) // If we find a good node that is connected to bad node, return the whole set
            {
                int nodeStart = invocations[i][0], nodeEnd = invocations[i][1];
                if (!bad[nodeStart] && bad[nodeEnd]) return Enumerable.Range(0, n).ToList();
            }

            List<int> result = new List<int>();
            for (int i=0; i<n; i++)
            {
                if (bad[i]) continue;
                result.Add(i);
            }

            PrettyPrint(result);
            return result;
        }
    }
}
