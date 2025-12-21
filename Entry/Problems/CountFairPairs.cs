// LeetCode 2563
using System;
using System.Collections.Generic;

namespace _2563
{
    public static class Globals
    {
        public static int[] nums = { 0, 1, 7, 4, 4, 5 };
        public static int lower = 3;
        public static int upper = 6;
    }
    public class Program
    {
        public long CountFairPairs(int[] nums, int lower, int upper)
        {
            Array.Sort(nums);
            int low = 0;
            int high = nums.Length - 1;
            int sumLtUpper = 0;
            int sumLtLower = 0;
            while (low < high)
            {
                if (nums[low] + nums[high] > upper)
                {
                    high--;
                    continue;
                }

                if (nums[low] + nums[high] <= upper) sumLtUpper += high - low;

                int left = low+1;
                int right = high;
                int mid = 0;
                while (left <= right)
                {
                    mid = left + (right - left) / 2;
                    if (nums[mid] + nums[low] <= lower - 1)
                    {
                        left = mid + 1;
                        continue;
                    }
                    right = mid - 1;
                }
                left--;
                if (nums[left] + nums[low] <= lower - 1)
                    sumLtLower += (left > right) ? right - low : left - low;

                low++;
            }
            return Math.Abs(sumLtUpper - sumLtLower);
        }
    }
}