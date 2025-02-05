// LeetCode 1800
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 10, 20, 30, 5, 10, 50 };
    public static int[] nums1 = { 10, 20, 30, 40, 50 };
    public static int[] nums2 = { 12, 17, 15, 13, 10, 11, 12 };
}

namespace Solution
{
    public class Program
    {
        public int MaxAscendingSum(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i<nums.Length; i++)
            {
                int temp = nums[i];
                int currSum = 0;
                currSum += temp;
                for (int j = i + 1; j<nums.Length; j++)
                {
                    if (temp >= nums[j]) break;
                    currSum += nums[j];
                    temp = nums[j];
                }
                sum = (currSum < sum) ? sum : currSum;
            }
            return sum;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxAscendingSum(Globals.nums));
            Console.WriteLine(obj.MaxAscendingSum(Globals.nums1));
            Console.WriteLine(obj.MaxAscendingSum(Globals.nums2));
            return;
        }
    }
}