// LeetCode 3191
using System;
using System.Collections.Generic;

namespace _3191
{
    public static class Globals
    {
        public static int[] nums = { 0, 1, 1, 1 };
    }
    public class Program
    {
        public int MinOperations(int[] nums)
        {
            int operations = 0;
            for (int i=0; i<nums.Length; i++)
            {
                if (i + 2 >= nums.Length)
                {
                    if (nums[i] == 0) return -1;
                    continue;
                }
                if (nums[i] == 1) continue;

                for (int flip = i; flip < i+3; flip++)
                    nums[flip] ^= 1;
                operations++;
            }
            return operations;
        }
    }
}