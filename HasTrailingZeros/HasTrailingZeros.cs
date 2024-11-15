// LeetCode 2980
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };
    public static List<int> nums1 = new List<int>() { 2, 4, 8, 16 };
    public static List<int> nums2 = new List<int>() { 1, 3, 5, 7, 9 };
}

namespace Solution
{
    public class Program
    {
        public bool HasTrailingZeros(List<int> nums)
        {
            List<List<int>> subArrays = new List<List<int>>();
            List<int> subarray = new List<int>();
            this.GetAllSubArrays(nums, subArrays, subarray, 0); // Gets All Subarrays of size 2 or more

            foreach (List<int> list in subArrays)
            {
                int ans = 0;
                foreach (int i in list) ans |= i; // Bitwise OR all the elements in subarray
                ans &= 1;                         // Mask every bit except the zeroth bit
                if (ans == 0) return true;        // if the zeroth bit is zero then we know it has trailing zeros
            }
            return false;
        }

        public void GetAllSubArrays(List<int> nums, List<List<int>> subArrays, List<int> subarray, int index)
        {
            if (subarray.Count > 1) subArrays.Add(new List<int>(subarray));

            for (int i=index; i<nums.Count; i++)
            {
                subarray.Add(nums[i]);
                GetAllSubArrays(nums, subArrays, subarray, i + 1);
                subarray.RemoveAt(subarray.Count - 1);
            }
            return;
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.HasTrailingZeros(Globals.nums));
            Console.WriteLine(obj.HasTrailingZeros(Globals.nums1));
            Console.WriteLine(obj.HasTrailingZeros(Globals.nums2));
            return;
        }
    }
}