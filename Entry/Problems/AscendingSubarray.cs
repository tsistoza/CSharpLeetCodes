// LeetCode 1800
using System;
using System.Collections.Generic;

namespace _1800
{
    public static class Globals
    {
        public static int[] nums = { 10, 20, 30, 5, 10, 50 };
    }
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
    }
}