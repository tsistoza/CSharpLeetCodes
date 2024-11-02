using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 2, 2, 2, 2, 2 };
}

namespace Solution
{
    public class Program
    {
        public static int MaxLIS(List<int> nums)
        {
            int[] dp = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++) dp[i] = 1;

            for(int i=0; i<nums.Count; i++)
                for(int j=0; j<i; j++)
                    if (nums[j] < nums[i] && dp[i] < dp[j] + 1)
                        dp[i] = dp[j] + 1;

            return dp[nums.Count-1];
        }

        public static int findNumberOfLIS(List<int> nums)
        {
            int sum = 0;
            int longestIncSubseq = MaxLIS(nums);
            if (longestIncSubseq == 1)
            {
                foreach (int i in nums) sum++;
                return sum;
            }

            List<int> sortedNums = new List<int>();
            foreach(int i in nums) sortedNums.Add(i);
            sortedNums.Sort();
            List<int> subseq = new List<int>();

            for (int i = nums.Count - 1; i >= 0; i--)
            {
                subseq.Add(sortedNums[sortedNums.Count - 1]);
                for (int j = i; j >= 0; j--)
                {
                    if (nums[j] < subseq[subseq.Count - 1] && nums[j] < subseq[0]) subseq.Add(nums[j]);
                    if (subseq.Count == longestIncSubseq) sum++;
                }
                subseq.Clear();
            }
            return sum;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(findNumberOfLIS(Globals.nums));
            return;
        }
    }
}