// LeetCode 2154
using System;
using System.Collections.Generic;

namespace Solution
{
    public static class Globals
    {
        public static int[] nums = { 2, 7, 9 };
        public static int original = 4;
    }

    public class Program
    {
        public int FindFinalValue(int[] nums, int original)
        {
            Array.Sort(nums);

            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i] < original) continue;
                if (nums[i] > original) break;

                original *= 2;
            }
            return original;
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.FindFinalValue(Globals.nums, Globals.original));
            return;
        }
    }
}