// LeetCode 1437
using System;
using System.Collections.Generic;

namespace _1437
{
    public static class Globals
    {
        public static readonly List<int> nums = new List<int>() { 1, 0, 0, 0, 1, 0, 0, 1 };
        public static readonly int k = 2;
    }
    public class Program
    {
        public bool KLengthApart(List<int> nums, int k)
        {
            int distance = 0;
            for (int i = 0; i<nums.Count; i++)
            {
                if (nums[i] == 1 && distance != 0)
                {
                    if (distance < k) return false; 
                    distance = 0;
                    continue;
                }
                distance++;
            }
            return true;
        }
    }
}