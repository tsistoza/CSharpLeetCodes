// LeetCode 2529
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { -2, -1, -1, 1, 2, 3 };
    public static int[] nums1 = { -3, -2, -1, 0, 0, 1, 2 };
    public static int[] nums2 = { 5, 20, 66, 1314 };
}

namespace Solution
{
    public class Program
    {
        public int MaximumCount(int[] nums)
        {
            int posCount = 0, negCount = 0;
            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i] > 0) posCount++;
                if (nums[i] < 0) negCount++;
            }
            return (posCount > negCount) ? posCount : negCount;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaximumCount(Globals.nums));
            Console.WriteLine(obj.MaximumCount(Globals.nums1));
            Console.WriteLine(obj.MaximumCount(Globals.nums2));
            return;
        }
    }
}