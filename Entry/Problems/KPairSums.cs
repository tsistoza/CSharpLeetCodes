// LeetCode 373
using System;
using System.Collections.Generic;

namespace _373
{
    public static class Globals
    {
        public static int[] nums1 = { 1, 1, 2 };
        public static int[] nums2 = { 1, 2, 3 };
        public static int k = 2;
    }
    public class Program
    {
        private static void PrettyPrint(List<List<int>> result)
        {
            Console.Write("Result: ");
            for (int i=0; i<result.Count; i++)
                Console.Write($"({result[i][0]},{result[i][1]}) ");
            Console.WriteLine("\n\n");
            return;
        }
        public List<List<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            PriorityQueue<List<int>, int> queue = new PriorityQueue<List<int>, int>();
            for (int i=0; i<nums1.Length; i++)
                for (int j=0; j<nums2.Length; j++)
                    queue.Enqueue(new List<int> { nums1[i], nums2[j] }, nums1[i] + nums2[j]);


            List<List<int>> results = new List<List<int>>();
            for (int i=0; i<k; i++)
            {
                List<int> pair = queue.Dequeue();
                results.Add(pair);
            }

            queue.Clear();
            PrettyPrint(results);
            return results;
        }
    }
}
