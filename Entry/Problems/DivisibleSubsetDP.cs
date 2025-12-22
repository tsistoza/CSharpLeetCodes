// LeetCode 368
using System;
using System.Collections.Generic;

namespace _368DP
{
    public static class Globals
    {
        public static int[] nums = { 1, 2, 4, 8, 15, 16, 32 };
    }

    public class Program
    {
        public static void PrettyPrint(List<int> subset)
        {
            Console.Write("{ ");
            foreach (int i in subset)
                Console.Write($"{i}, ");
            Console.WriteLine("} ");
            return;
        }
        public List<int> LargestDivisibleSubset(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, -1);

            for (int i=0; i<nums.Length-1; i++)
            {
                for (int j=i+1; j<nums.Length; j++)
                {
                    if (nums[i] % nums[j] > 0 && nums[j] % nums[i] > 0) continue;
                    dp[i] = j;
                    break;
                }
            }

            List<int> result = new List<int>();
            for (int i=0; i<dp.Length; i++)
            {
                List<int> curr = new List<int>();
                curr.Add(nums[i]);
                int index = i;
                while (dp[index] != -1)
                {
                    curr.Add(nums[dp[index]]);
                    index = dp[index];
                }

                if (curr.Count > result.Count) result = curr;
            }

            return result;
        }
    }
}