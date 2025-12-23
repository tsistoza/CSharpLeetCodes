// LeetCode 128
using System;

namespace _128
{
    public static class Globals
    {
        public static int[] nums = { 100, 4, 200, 1, 3, 2 };
    }
    public class Program
    {
        public int LongestConsecutive(int[] nums)
        {
            int sum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            
            foreach (int i in nums)
            {
                if (map.ContainsKey(i)) continue;
                map.Add(i, i + 1);
            }

            foreach (int i in nums)
            {
                int key = i;
                int tempSum = 0;
                while (map.ContainsKey(key))
                {
                    tempSum++;
                    key++;
                }
                sum = (sum < tempSum) ? tempSum : sum;
            }
            return sum;
        }
    }
}