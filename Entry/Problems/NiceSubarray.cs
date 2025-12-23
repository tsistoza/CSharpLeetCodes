// LeetCode 2401
using System;
using System.Collections.Generic;

namespace _2401
{
    public static class Globals
    {
        public static int[] nums = { 3, 1, 5, 11, 13 };
    }
    public class Program
    {
        public int LongestNiceSubarray(int[] nums)
        {
            int max = int.MinValue;
            for (int i=0; i<nums.Length; i++)
            {
                List<int> subarray = new List<int>() { nums[i] };
                for (int j=i+1; j<nums.Length; j++)
                {
                    int k = 0;
                    for (; k<subarray.Count; k++)
                        if ((subarray[k] & nums[j]) != 0) break;

                    if (k == subarray.Count) subarray.Add(k);
                    else break;
                }
                max = Math.Max(max, subarray.Count);
            }

            return max;
        }
    }
}