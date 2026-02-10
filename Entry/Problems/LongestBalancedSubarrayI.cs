using System;
using System.Collections.Generic;

namespace _3719
{
    public static class Globals
    {
        public static int[] nums = { 2, 5, 4, 3 };
    }
    public class Program
    {
        private bool isValid(int start, int end, int[] nums)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            for (int i=start; i<=end; i++)
            {
                if (!count.TryAdd(nums[i], 1))
                    count[nums[i]]++;
            }
            int even = 0, odd = 0;

            foreach (int key in count.Keys)
            {
                if (key % 2 == 0) even++;
                else odd++;
            }
            return even == odd;
        }
        public int LongestBalanced(int[] nums) // Brute Force
        {
            for (int length=nums.Length; length > 1; length--)
            {
                for (int start=0; start+length-1 < nums.Length; start++)
                {
                    if (isValid(start, start + length - 1, nums))
                        return length;
                }
            }

            return 0;
        }
    }
}
