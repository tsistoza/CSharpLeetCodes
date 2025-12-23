// LeetCode 1855
using System;
using System.Collections.Generic;

namespace _1855
{
    public static class Globals
    {
        public static int[] nums1 = { 55, 30, 5, 4, 2 };
        public static int[] nums2 = { 100, 20, 10, 10, 5 };
    }
    public class Program
    {
        public int MaxDistance(int[] nums1, int[] nums2)
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
    }
}