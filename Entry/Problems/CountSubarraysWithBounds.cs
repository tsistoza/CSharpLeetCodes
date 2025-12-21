// LeetCode 2444
using System;
using System.Collections.Generic;

namespace _2444
{
    public static class Globals
    {
        public static int[] nums = { 1, 1, 1, 1 };
        public static int minK = 1;
        public static int maxK = 1;
    }
    public class Program
    {
        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            long ans = 0;
            int minKIdx = -1;
            int maxKIdx = -1;
            int invalidIdx = -1;
            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i] == minK) minKIdx = i;
                if (nums[i] == maxK) maxKIdx = i;
                if (nums[i] < minK || nums[i] > maxK)
                    invalidIdx = i;

                ans += (long) Math.Max(0, Math.Min(minKIdx, maxKIdx) - invalidIdx);
            }
            return ans;
        }
    }
}
