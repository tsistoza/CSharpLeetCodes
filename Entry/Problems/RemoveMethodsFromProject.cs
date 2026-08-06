// LeetCode 3310
using System;
using System.Collections.Generic;

namespace _3310
{
    public static class Globals
    {
        public static int n = 5;
        public static int k = 0;
        public static int[][] invocations = new int[4][]
        {
            new int[] { 1, 2 },
            new int[] { 0, 2 },
            new int[] { 0, 1 },
            new int[] { 3, 4 }
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
        private void dfs(Dictionary<int, List<int>> adjList, HashSet<int> suspicious, int node, bool isSuspicious)
        {
            if (!adjList.ContainsKey(node)) return;

            for (int i=0; i<adjList[node].Count; i++)
            {
                int nextNode = adjList[node][i];
                if (isSuspicious && !suspicious.Contains(nextNode)) suspicious.Add(nextNode);
                if (!isSuspicious && suspicious.Contains(nextNode)) suspicious.Remove(nextNode);
                dfs(adjList, suspicious, nextNode, isSuspicious);
            }
            return;
        }
        public List<int> RemainingMethods(int n, int k, int[][] invocations)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            for (int i=0; i<invocations.Length; i++)
            {
                int start = invocations[i][0], end = invocations[i][1];
                if (adjList.ContainsKey(start))
                    adjList[start].Add(end);
                else
                    adjList.Add(start, new List<int>() { end });
            }

            HashSet<int> suspicious = new HashSet<int>();
            suspicious.Add(k);
            dfs(adjList, suspicious, k, true);

            for (int i=0; i<n; i++)
            {
                if (i == k) continue;
                if (!adjList.ContainsKey(i)) continue;

                bool isSuspicious = suspicious.Contains(i);
                if (isSuspicious) continue;

                dfs(adjList, suspicious, i, isSuspicious);
            }

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
