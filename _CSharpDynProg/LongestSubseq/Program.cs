using System;
using System.Collections.Generic;
using System.Globalization;

public static class Globals
{
    public static List<int> nums = new List<int>() { 10, 9, 2, 5, 3, 7, 101, 18 };
}

namespace Solution
{
    public class Program
    {
        public static int LengthOfLIST(List<int> nums)
        {
            int[] dp = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++) dp[i] = 1;
            for (int i=0; i<nums.Count; i++)
            {
                for(int j=0; j<i; j++)
                {
                    Console.WriteLine($"{nums[i]} : {nums[j]}");
                    if (nums[i] > nums[j] && dp[i] < dp[j]+1)
                        dp[i] = dp[j] + 1;
                    Console.WriteLine(dp[i]);
                }
            }
            return dp[nums.Count-1];
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLIST(Globals.nums));
            return;
        }
    }
}