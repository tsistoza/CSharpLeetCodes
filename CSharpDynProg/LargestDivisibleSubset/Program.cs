using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> list = new List<int>() { 1, 7, 8, 16, 32 };
}


namespace Solution
{
    public class Program
    {
        public static List<int> LargestDivisibleSubset(List<int> nums)
        {
            List<int> res = new List<int>();
            int[] dp = new int[nums.Count];

            for(int i=0; i<nums.Count; i++) dp[i] = 1;

            for(int i=0; i<nums.Count; i++)
            {
                for(int j=0; j<i; j++)
                {
                    if ((nums[i] % nums[j] == 0) && dp[i] < dp[j] + 1)
                    {
                        res.Add(nums[j]);
                        dp[i] = dp[j] + 1;
                    }
                }
                if (i != nums.Count - 1) res.Clear();
                if (i == nums.Count - 1) res.Add(nums[i]);
            }
            return res;
        }

        public static void Main()
        {
            foreach(int i in LargestDivisibleSubset(Globals.list))
            {
                Console.WriteLine(i);
            }
            return;
        }
    }
}