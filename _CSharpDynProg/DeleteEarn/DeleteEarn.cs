using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 3, 4, 2 };
}

namespace Solution
{
    public class Program
    {
        public static List<int> Clone(List<int> nums)
        {
            List<int> clone = new List<int>();
            foreach (int x in nums) clone.Add(x);
            return clone;
        }

        public static int DeleteAndEarn(List<int> nums)
        {
            int[] dp = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++) dp[i] = nums[i];
            List<int> numsCopy = Clone(nums);
            numsCopy.Sort();

            for (int i=0; i<nums.Count; i++)
            {
                int remove = nums[i];
                numsCopy.Remove(remove);
                while (numsCopy.Count > 0)
                {
                    foreach (int x in nums) // Remove All n+1, n-1
                    {
                        if (x == remove + 1) numsCopy.Remove(x);
                        if (x == remove - 1) numsCopy.Remove(x);
                    }
                    if (numsCopy.Count == 0) break;
                    dp[i] += numsCopy[numsCopy.Count - 1];
                    remove = numsCopy[numsCopy.Count - 1];
                    numsCopy.Remove(remove);
                }
                numsCopy = Clone(nums);
            }
            
            Array.Sort(dp);
            return dp[nums.Count-1];
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(DeleteAndEarn(Globals.nums));
            return;
        }
    }
}