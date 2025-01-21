// LeetCode 2962
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

public static class Globals
{
    public static int[] nums = { 1, 3, 2, 3, 3 };
    public static int k = 2;
    public static int[] nums1 = { 1, 4, 2, 1 };
    public static int k1 = 2;
}

namespace Solution
{
    public class Program
    {
        public long CountSubarrays(int[] nums, int k)
        {
            long result = 0;
            
            for (int i=0; i<nums.GetLength(0); i++)
            {
                int currElem = 0;
                List<int> subarray = new List<int>();
                subarray.Add(nums[i]);
                if (nums[i] == nums.Max()) currElem++;
                if (currElem >= k) result++;
                for (int j=i+1; j<nums.GetLength(0); j++)
                {
                    subarray.Add(nums[j]);
                    if (nums[j] == nums.Max()) currElem++;
                    if (currElem >= k) result++;
                }
            }
            return result;
        }
        
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CountSubarrays(Globals.nums, Globals.k));
            Console.WriteLine(obj.CountSubarrays(Globals.nums1, Globals.k1));
            return;
        }
    }
}