// LeetCode 2535
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 1, 15, 6, 3 };
    public static int[] nums1 = { 1, 2, 3, 4 };
}

namespace Solution
{
    public class Program
    {
        public static int DifferenceOfSum(int[] nums)
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
        public static void Main()
        {
            Console.WriteLine(DifferenceOfSum(Globals.nums));
            Console.WriteLine(DifferenceOfSum(Globals.nums1));
            return;
        }
    }
}