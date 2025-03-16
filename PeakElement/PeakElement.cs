// LeetCode 162
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 1, 2, 1, 3, 5, 6, 4 };
}

namespace Solution
{
    public class Program
    {
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 1) return 0;
            if (nums.Length == 2) return (nums[0] < nums[1]) ? 1 : 0;

            int middle = (int) ((nums.Length - 1) / 2);
            if ((nums.Length - 1) % 2 == 1) middle++;
            if (nums[middle + 1] < nums[middle] && nums[middle - 1] < nums[middle]) return middle; // check if middle is a peak

            // Since we dont have a peak at middle, there has to be a peak either on the right or left, because middle + 1 > middle or middle - 1 > middle

            // Check right side of array
            int ptr = middle;
            if (nums[ptr + 1] > nums[ptr++])
            {
                while (ptr < nums.Length)
                    if (nums[ptr + 1] < nums[ptr++]) break;
                return ptr - 1;
            }

            // Otherwise check left side of array
            ptr--;
            while (ptr >= 0)
                if (nums[ptr - 1] < nums[ptr--]) break;
            return ptr + 1;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.FindPeakElement(Globals.nums));
            return;
        }
    }
}