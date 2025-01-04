// LeetCode 2270
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 10, 4, -8, 7 };
    public static int[] nums1 = { 2, 3, 1, 0 };
}

namespace Solution
{
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
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.WaysToSplitArray(Globals.nums));
            Console.WriteLine(obj.WaysToSplitArray(Globals.nums1));
            return;
        }
    }
}