﻿// LeetCode 2570
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] nums1 = { { 1, 2 }, { 2, 3 }, { 4, 5 } };
    public static int[,] nums2 = { { 1, 4 }, { 3, 2 }, { 4, 1 } };
    public static int[,] nums1a = { { 2, 4 }, { 3, 6 }, { 5, 5 } };
    public static int[,] nums2a = { { 1, 3 }, { 4, 3 } };
}

namespace Solution
{
    public class Program
    {
        private static void prettyPrint(List<List<int>> array)
        {
            Console.Write("{ ");
            foreach (List<int> list in array)
            {
                Console.Write("{ ");
                foreach (int i in list)
                    Console.Write($"{i}, ");
                Console.Write("}, ");
            }
            Console.WriteLine("}");
            return;
        }
        public List<List<int>> MergeArrays(int[,] nums1, int[,] nums2)
        {
            List<List<int>> merge = new List<List<int>>();

            int left = 0, right = 0;
            for (; left<nums1.GetLength(0) && right<nums2.GetLength(0);)
            {
                if (nums1[left, 0] == nums2[right, 0])
                    merge.Add(new List<int>() { nums1[left, 0], nums1[left++, 1] + nums2[right++, 1] });
                else if (nums1[left, 0] < nums2[right, 0])
                    merge.Add(new List<int>() { nums1[left, 0], nums1[left++, 1] });
                else
                    merge.Add(new List<int>() { nums2[right, 0], nums2[right++, 1] });
            }

            if (left < nums1.GetLength(0))
                while (left < nums1.GetLength(0))
                    merge.Add(new List<int>() { nums1[left, 0], nums1[left++, 1] });

            if (right < nums2.GetLength(0))
                while(right < nums2.GetLength(0))
                    merge.Add(new List<int>() { nums2[right, 0], nums2[right++, 1] });

            return merge;
        }
        public static void Main()
        {
            Program obj = new Program();
            prettyPrint(obj.MergeArrays(Globals.nums1, Globals.nums2));
            prettyPrint(obj.MergeArrays(Globals.nums1a, Globals.nums2a));
            return;
        }
    }
}