// LeetCode 719
using System;
using System.Collections.Generic;

namespace _719
{
    public static class Globals
    {
        public static int[] nums = { 1, 6, 1 };
        public static int k = 3;
    }
    public class Program
    {
        public int CountPairWithDistanceLTMid(int[] nums, int mid)
        {
            int left = 0, right = 0, count = 0;
            while (right < nums.Length) 
            {
                while (nums[right] - nums[left] > mid) left++;
                count += (right - left);
                right++;

            }
            return count;
        }
            
        public int SmallestDistancePair(int[] nums, int k)
        {
            Array.Sort(nums);
            int low = 0, high = nums[nums.Length - 1] - nums[0];
            while (low < high)
            {
                int mid = low + (high-low) / 2;
                int countPairsLTMid = CountPairWithDistanceLTMid(nums, mid);
                Console.WriteLine($"low={low}, mid={mid}, high={high}, pairsLTMid={countPairsLTMid}");

                if (countPairsLTMid < k)
                    low = mid + 1;
                else
                    high = mid;
            }

            Console.WriteLine($"low={low}, high={high}");
            return low;
        }
    }
}
