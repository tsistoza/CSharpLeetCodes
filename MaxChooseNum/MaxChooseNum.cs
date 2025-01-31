// LeetCode 2554
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> banned = new List<int>() { 1, 6, 5 };
    public static int n = 5;
    public static int maxSum = 6;

    public static List<int> banned1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
    public static int n1 = 8;
    public static int maxSum1 = 1;

    public static List<int> banned2 = new List<int>() { 11 };
    public static int n2 = 7;
    public static int maxSum2 = 50;
}

namespace Solution
{
    public class Program
    {
        private int findSum(List<int> arr)
        {
            int sum = 0;
            foreach (int i in arr) sum += i;
            return sum;
        }
        private void getCombinations(ref int count, List<int> nums, List<int> sum, int maxSum, int index)
        {
            if (findSum(sum) <= maxSum)
                count = (count < sum.Count) ? sum.Count : count;
            else return;

            if (index > nums.Count - 1) return;

            // Add current index
            List<int> temp = new List<int>(sum);
            temp.Add(nums[index]);
            getCombinations(ref count, nums, temp, maxSum, index + 1);

            if (sum.Count == 0) return;
            // Remove back of list, then add current index
            List<int> temp1 = new List<int>(sum);
            temp1.RemoveAt(temp1.Count - 1);
            temp1.Add(nums[index]);
            getCombinations(ref count, nums, temp1, maxSum, index + 1);
            return;
        }

        public int MaxCount(List<int> banned, int n, int maxSum)
        {
            List<int> available = new List<int>();
            int count = 0;
            for (int i=1; i<=n; i++)
            {
                if (banned.Contains(i)) continue;
                available.Add(i);
            }

            if (available.Count <= 0) return count;
            getCombinations(ref count, available, new List<int>(), maxSum, 0);

            return count;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxCount(Globals.banned, Globals.n, Globals.maxSum));
            Console.WriteLine(obj.MaxCount(Globals.banned1, Globals.n1, Globals.maxSum1));
            Console.WriteLine(obj.MaxCount(Globals.banned2, Globals.n2, Globals.maxSum2));
            return;
        }
    }
}