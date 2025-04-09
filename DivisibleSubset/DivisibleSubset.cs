// LeetCode 368
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 1, 2, 4, 8 };
}

namespace Solution
{
    public class Program
    {
        private static void prettyPrint(List<int> subset)
        {
            Console.Write("{ ");
            for (int i=0; i<subset.Count; i++)
                Console.Write($"{subset[i]} ,");
            Console.WriteLine(" }");
            return;
        }
        private bool isDivisible(List<int> subset)
        {
            if (subset.Count == 0 || subset.Count == 1) return false;
            for (int i=0; i<subset.Count-1; i++)
                if (subset[i] % subset[i + 1] > 0 && subset[i+1] % subset[i] > 0) return false;

            return true;
        }
        private void findSubset(List<int> subset, ref List<int> largestSubset, int[] nums)
        {
            if (largestSubset.Count > 0) return;
            if (isDivisible(subset))
            {
                largestSubset = subset;
                return;
            }

            for (int i=0; i<subset.Count; i++)
            {
                List<int> temp = new List<int>(subset);
                temp.RemoveAt(i);
                findSubset(temp, ref largestSubset, nums);
            }

            return;
        }

        // Brute Force, will be doing a more optimized version of this using dynamic programming
        public List<int> LargestDivisibleSubset(int[] nums)
        {
            List<int> largestSubset = new List<int>();
            findSubset(nums.ToList(), ref largestSubset, nums);
            return largestSubset;
        }
        public static int Main()
        {
            Program obj = new Program();
            Program.prettyPrint(obj.LargestDivisibleSubset(Globals.nums));
            return 0;
        }
    }
}