// LeetCode 1863
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 3, 4, 5, 6, 7, 8 };
}

namespace Solution
{
    public class Program
    {
        private int XorTotal(List<int> subset)
        {
            if (subset.Count == 0) return 0;
            if (subset.Count == 1) return subset[0];
            int sum = subset[0];

            for (int i=1; i<subset.Count; i++)
                sum ^= subset[i];
            return sum;
        }
        private int recursion(List<int> subset, int[] nums, int index)
        {
            int sum = XorTotal(subset);

            if (index >= nums.Length) return sum;

            List<int> temp = new List<int>(subset);

            if (subset.Count != 0)
            {
                temp.RemoveAt(temp.Count - 1);
                temp.Add(nums[index]);
                sum += recursion(temp, nums, index + 1);
            }
            temp = new List<int>(subset);
            temp.Add(nums[index]);
            sum += recursion(temp, nums, index + 1);

            return sum;
        }
        public int SubsetXORSum(int[] nums)
        {
            return recursion(new List<int>(), nums, 0);
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.SubsetXORSum(Globals.nums));
            return;
        }
    }
}