// LeetCode 2529
using System;
using System.Collections.Generic;

namespace _2529
{
    public static class Globals
    {
        public static int[] nums = { -2, -1, -1, 1, 2, 3 };
    }
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
    }
}