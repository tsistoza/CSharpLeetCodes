// LeetCode 3201
using System;
using System.Collections.Generic;

namespace _3201
{
    public static class Globals
    {
        public static int[] nums = { 1, 2, 2, 2, 2, 2, 2, 2 };
    }
    public class Program
    {
        public int MaximumLength(int[] nums)
        {
            int largest = 0;
            List<List<int>> dp = new List<List<int>>();
            for (int i=0; i<nums.Length; i++)
            {
                if (dp.Count > 0)
                {
                    for (int j=0; j<dp.Count; j++)
                    {
                        bool even = (j % 2) == 0;

                        if (even && (dp[j][dp[j].Count-1] + nums[i]) % 2 == 0) dp[j].Add(nums[i]);
                        if (!even && (dp[j][dp[j].Count - 1] + nums[i]) % 2 == 1) dp[j].Add(nums[i]);

                        largest = Math.Max(largest, dp[j].Count);
                    }
                }

                dp.Add(new List<int> { nums[i] }); // even index
                dp.Add(new List<int> { nums[i] }); // odd index
            }

            return largest;
        }
    }
}