// LeetCode 169
using System;
using System.Collections.Generic;

namespace _169
{
    public static class Globals
    {
        public static int[] nums = { 3, 2, 3 };
    }
    public class Program
    {
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int seen = (int)Math.Round((decimal)(nums.GetLength(0)/2));
            foreach (int i in nums)
            {
                if (!map.ContainsKey(i))
                {
                    map.Add(i, 1);
                    continue;
                }
                if (map[i] >= seen) return i;
                map[i]++;
            }
            return 0;
        }
    }
}