// LeetCode 416
using System;
using System.Collections.Generic;

namespace _416
{
    public static class Globals
    {
        public static int[] nums = { 1 };
    }
    public class Program
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            foreach (int i in nums) sum += i;
            if (sum % 2 == 1) return false;

            bool[] dp = new bool[(sum / 2) + 1];
            Array.Fill(dp, false);
            dp[0] = true;
            for (int i=0; i<nums.Length; i++)
            {
                for (int j=sum/2; j>0; j--)
                {
                    //Console.WriteLine($"j = {j}, nums[i] = {nums[i]}, j-nums[i]= {j - nums[i]}");
                    bool expr = false;
                    if (j - nums[i] >= 0) expr = dp[j - nums[i]];
                    dp[j] |= expr;
                }
            }

            return dp[sum/2];
        }
    }
}