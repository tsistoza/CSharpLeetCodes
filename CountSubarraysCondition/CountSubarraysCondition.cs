// LeetCode 3392
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 1, 1, 1 };
}

namespace Solution
{
    public class Program
    {
        public int CountSubarrays(int[] nums)
        {
            int count = 0;
            for (int left = 0, right = left + 2; right < nums.Length; left++, right++)
            {
                int mid = left + (right - left) / 2;
                count += ((float)(nums[left] + nums[right]) == (float)nums[mid] / 2.0f) ? 1 : 0;
            }
            return count;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CountSubarrays(Globals.nums));
            return;
        }
    }
}