// LeetCode 2270
using System;
using System.Collections.Generic;

namespace _2270
{
    public static class Globals
    {
        public static int[] nums = { 10, 4, -8, 7 };
    }
    public class Program
    {
        public int WaysToSplitArray(int[] nums)
        {
            int splits = 0;
            int rightSum = 0;
            for (int i=0; i<nums.Length; i++)
                rightSum += nums[i];

            int leftSum = 0;
            for (int i=0; i<nums.Length-1; i++)
            {
                leftSum += nums[i];
                rightSum -= nums[i];
                if (leftSum >= rightSum) splits++;
            }

            return splits;
        }
    }
}