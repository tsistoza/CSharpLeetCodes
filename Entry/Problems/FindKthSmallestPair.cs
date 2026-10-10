// LeetCode 719
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace _719
{
    public static class Globals
    {
        public static int[] nums = { 1, 6, 1 };
        public static int k = 3;
    }
    public class Program
    {
        private int CountPairs(int[] sortedNums, int distance)
        {
            int n = sortedNums.Length;
            int count = 0;

            int left = 0;
            for (int i=0; i<n; i++)
            {
                while (sortedNums[i] - sortedNums[left] > distance)
                    left++;

                count += i - left;
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
                int countOfPairs = CountPairs(nums, mid);
                Console.WriteLine($"low={low}, mid={mid}, high={high}, countPairs={countOfPairs}");

                if (countOfPairs < k)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            Console.WriteLine($"low={low} high={high}");
            int pairs = CountPairs(nums, low);
            return (pairs < k) ? low + 1 : low;
        }
    }
}
