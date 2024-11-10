// LeetCode 3097
using System;
using System.Collections.Generic;

public static class Globals
{
    public static readonly List<int> nums = new List<int>() { 1, 2, 3 };
    public static readonly int k1 = 2;
    public static readonly List<int> nums2 = new List<int>() { 2, 1, 8 };
    public static readonly int k2 = 10;
}

namespace Solution
{
    public class Program
    {
        public int MinimumSubarrayLength(List<int> nums, int k)
        {
            List<int> dp = new List<int>();
            List<List<int>> listSubArray = new List<List<int>>();
            List<int> subArray = new List<int>();
            
            CreateSubArray(listSubArray, subArray, nums, 0, k);

            foreach (List<int> list in listSubArray)
                dp.Add(list.Count);
            dp.Sort();
            return dp[0];
        }

        private void CreateSubArray(List<List<int>> listSubArray, List<int> subarray, List<int> nums, int index, int k)
        {
            // We are going to implement this
            // https://www.geeksforgeeks.org/backtracking-to-find-all-subsets/

            if (subarray.Count > 0)
            {
                int bitOr = subarray[0];
                for (int i = 1; i < subarray.Count; i++)
                    bitOr |= (int)subarray[i];
                if (bitOr > k) listSubArray.Add(new List<int>(subarray)); // check if the subarray is greater than k, bitwised
            }

            for (int i = index; i < nums.Count; i++)
            {
                subarray.Add(nums[i]); // include current element in subset

                CreateSubArray(listSubArray, subarray, nums, i+1, k); // include the next element in the subset

                subarray.RemoveAt(subarray.Count-1); // exclude current element in subset
            }
            return;
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine(obj.MinimumSubarrayLength(Globals.nums, Globals.k1));
            Console.WriteLine(obj.MinimumSubarrayLength(Globals.nums2, Globals.k2));
            return;
        }
    }
}
