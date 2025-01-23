// LeetCode 493
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 1, 3, 2, 3, 1 };
    public static int[] nums1 = { 2, 4, 3, 5, 1 };
    public static int[] nums2 = { int.MaxValue, -int.MaxValue, int.MaxValue, -int.MaxValue, int.MaxValue, int.MaxValue };
}

namespace Solution
{
    public class Program
    {
        public int ReversePairs(int[] nums)
        {
            int count = 0;

            for (int i=0; i<nums.Length; i++)
            {
                for (int j=i+1; j<nums.Length; j++)
                {
                    if (nums[i] <= nums[j]) continue;
                    if (nums[i] > (long) 2 * nums[j]) count++;
                }
            }
            return count;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.ReversePairs(Globals.nums));
            Console.WriteLine(obj.ReversePairs(Globals.nums1));
            Console.WriteLine(obj.ReversePairs(Globals.nums2));
            return;
        }
    }
}