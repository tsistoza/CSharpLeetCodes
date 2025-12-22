// LeetCode 41
using System;
using System.Collections.Generic;

namespace _41
{
    public static class Globals
    {
        public static int[] nums = { 7, 8, 9, 11, 12 };
    }
    public class Program
    {
        public int firstMissingPositive(int[] nums)
        {
            bool[] bools = new bool[nums.Length];
            Array.Fill(bools, false);
            
            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i] > nums.Length || nums[i] <= 0) continue;
                bools[nums[i] - 1] = true;
            }

            for (int i = 0; i < bools.Length; i++)
                if (bools[i] == false) return i + 1;
            return nums.Length + 1;
        }
    }
}