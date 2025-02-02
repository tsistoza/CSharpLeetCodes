// LeetCode 1752
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 3, 4, 5, 1, 2 };
    public static int[] nums1 = { 2, 1, 3, 4 };
    public static int[] nums2 = { 1, 2, 3 };
}

namespace Solution
{
    public class Program
    {
        public bool Check(int[] nums)
        {
            int[] sorted = new int[nums.Length];
            Array.Copy(nums, sorted, nums.Length);
            Array.Sort(sorted);

            int x = 0;
            for (; x<nums.Length; x++)
                if (nums[x] == sorted[0]) break;

            for (int i = 0; i < sorted.Length; i++)
                if (sorted[i] != nums[(i + x) % sorted.Length]) return false;
            
            return true;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.Check(Globals.nums));
            Console.WriteLine(obj.Check(Globals.nums1));
            Console.WriteLine(obj.Check(Globals.nums2));
            return;
        }
    }
}