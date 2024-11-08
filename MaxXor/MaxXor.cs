// LeetCode 1829
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 0, 1, 1, 3 };
    public static readonly int maxBit1 = 2;
    public static List<int> nums2 = new List<int>() { 2, 3, 4, 7 };
    public static readonly int maxBit2 = 3;
    public static List<int> nums3 = new List<int>() { 0, 1, 2, 2, 5, 7 };
    public static readonly int maxBit3 = 3;
}

namespace Solution
{
    public class Program
    {
        public List<int> GetMaximumXor(List<int> nums, int maxBit)
        {
            List<int> result = new List<int>();
            int queryResult = (int) Math.Pow(2, maxBit) - 1;
            while (nums.Count > 0)
            {
                int k = nums[0];
                IEnumerator<int> iter = nums.GetEnumerator();
                iter.MoveNext();
                while (iter.MoveNext()) k ^= iter.Current;
                k ^= queryResult;
                result.Add(k);
                nums.RemoveAt(nums.Count - 1);
            }
            return result;
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();
            foreach (int i in obj.GetMaximumXor(Globals.nums, Globals.maxBit1))
                Console.Write($"{i} ");
            Console.WriteLine();
            foreach (int i in obj.GetMaximumXor(Globals.nums2, Globals.maxBit2))
                Console.Write($"{i} ");
            Console.WriteLine();
            foreach (int i in obj.GetMaximumXor(Globals.nums3, Globals.maxBit3))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}