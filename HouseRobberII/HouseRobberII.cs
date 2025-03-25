// LeetCode 213
// House Robber I is in CPPLeetCode
using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

public static class Globals
{
    public static List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
}

namespace Solution
{
    public class Program
    {
        public int rob(List<int> nums)
        {
            if (nums.Count == 3)
                return Enumerable.Max(nums);

            int[] dp = new int[nums.Count-1];
            int[] dp2 = new int[nums.Count-1];

            for (int i=0; i<nums.Count-1; i++)
            {
                if (i == 0 | i == 1)
                {
                    dp[i] = nums[i];
                    continue;
                }

                if (i == 2)
                {
                    dp[2] = dp[0] + nums[2];
                    continue;
                }

                dp[i] = Math.Max(dp[i - 2], dp[i - 3]) + nums[i];
            }

            for (int i=1; i<nums.Count; i++)
            {
                if (i == 1 || i == 2)
                {
                    dp2[i-1] = nums[i];
                    continue;
                }

                if (i == 3)
                {
                    dp2[i - 1] = dp2[0] + nums[i];
                    continue;
                }

                dp2[i - 1] = Math.Max(dp2[i - 3], dp[i - 4]) + nums[i];
            }
            int max = Math.Max(Math.Max(dp[nums.Count-2], dp[nums.Count-3]), Math.Max(dp2[nums.Count-2], dp[nums.Count-3]));
            return max;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.rob(Globals.nums));
            return;
        }
    }
}