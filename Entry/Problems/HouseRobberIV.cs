// LeetCode 2560
using System;
using System.Collections.Generic;

namespace _2560
{
    public static class Globals
    {
        public static int[] nums = { 2, 7, 9, 3, 1 };
        public static int k = 2;
    }
    public class Program
    {
        
        public int MinCapabiliity(int[] nums, int k)
        {
            int low = 1;
            int high = nums[0];
            for (int i=1; i<nums.Length; i++)
                high = Math.Max(high, nums[i]);
            
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                int housesRobbed = 0;

                for (int i=0; i < nums.Length;)
                {
                    if (nums[i] <= mid)
                    {
                        housesRobbed++;
                        i += 2;
                        continue;
                    }
                    i++;
                }

                if (housesRobbed < k) low = mid + 1;
                else high = mid;
            }
            return low;
        }
    }
}