// LeetCode 1855
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums1 = { 55, 30, 5, 4, 2 };
    public static int[] nums2 = { 100, 20, 10, 10, 5 };
    public static int[] nums1a = { 2, 2, 2 };
    public static int[] nums2a = { 10, 10, 1 };
    public static int[] nums1b = { 30, 29, 19, 5 };
    public static int[] nums2b = { 25, 25, 25, 25, 25 };
}

namespace Solution
{
    public class Program
    {
        public static int MaxDistance(int[] nums1, int[] nums2)
        {
            int max = int.MinValue;
            for (int i=0; i<nums1.Length; i++)
            {
                for (int j=i; j<nums2.Length; j++)
                {
                    if (nums1[i] <= nums2[j])
                    {
                        int distance = j - i;
                        max = (max < distance) ? distance : max;
                    }
                }
            }
            return max;
        }
        public static void Main()
        {
            Console.WriteLine(MaxDistance(Globals.nums1, Globals.nums2));
            Console.WriteLine(MaxDistance(Globals.nums1a, Globals.nums2a));
            Console.WriteLine(MaxDistance(Globals.nums1b, Globals.nums2b));
            return;
        }
    }
}