// LeetCode 2425
using System;
using System.Collections.Generic;

public static class Globals
{
    public static readonly List<int> nums1 = new List<int>() { 2, 1, 3 };
    public static readonly List<int> nums2 = new List<int>() { 10, 2, 5, 0 };
    public static readonly List<int> nums3 = new List<int>() { 1, 2 };
    public static readonly List<int> nums4 = new List<int>() { 3, 4 };
}

namespace Solution
{
    public class Program
    {
        public int XorAllNums(List<int> nums1, List<int> nums2)
        {
            List<int> nums3 = new List<int>();

            // Get All Pair Combinations between nums1, nums2
            foreach (int i in nums1)
            {
                // For each pair XOR them to get a value for nums3
                foreach (int j in nums2) nums3.Add(i ^ j);
            }

            IEnumerator<int> enumerator = nums3.GetEnumerator();
            enumerator.MoveNext(); // move the enumerator to get first value
            int ans = enumerator.Current;
            while (enumerator.MoveNext()) // XOR All numbers in nums3
                ans ^= enumerator.Current;

            return ans;
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine(obj.XorAllNums(Globals.nums1, Globals.nums2));
            Console.WriteLine(obj.XorAllNums(Globals.nums3, Globals.nums4));
            return;
        }
    }
}