// LeetCode 1752
using System;
using System.Collections.Generic;

namespace _1752
{
    public static class Globals
    {
        public static int[] nums = { 3, 4, 5, 1, 2 };
    }
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
    }
}
