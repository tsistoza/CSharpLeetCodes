// LeetCode 2535
using System;
using System.Collections.Generic;

namespace _2535
{
    public static class Globals
    {
        public static int[] nums = { 1, 15, 6, 3 };
    }
    public class Program
    {
        public int DifferenceOfSum(int[] nums)
        {
            int elementSum = 0;
            int digitSum = 0;
            for (int i = 0; i<nums.Length; i++)
            {
                elementSum += nums[i];
                foreach (char c in Convert.ToString(nums[i]))
                {
                    string s = c.ToString();
                    digitSum += Convert.ToInt32(s);
                }
            }
            return (int)Math.Abs(digitSum - elementSum);
        }
    }
}