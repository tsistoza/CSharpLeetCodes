// LeetCode 1829
using System;
using System.Collections.Generic;

namespace _1829
{
    public static class Globals
    {
        public static List<int> nums = new List<int>() { 0, 1, 1, 3 };
        public static readonly int maxBit1 = 2;
    }
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
    }
}