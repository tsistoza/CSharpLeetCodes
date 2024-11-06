// Leetcode 3011
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 8, 4, 2, 30, 15 };
    public static List<int> nums2 = new List<int>() { 1, 2, 3, 4, 5 };
    public static List<int> nums3 = new List<int>() { 3, 16, 8, 4, 2 };
}

namespace Solution
{
    public class BitComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x < y && this.sameSetBits(x, y)) return -1;
            if (x > y && this.sameSetBits(x, y)) return 1;
            return 0;
        }
        public bool sameSetBits(int num1, int num2)
        {
            int i = num1;
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
            int j = num2;
            j = j - ((j >> 1) & 0x55555555);
            j = (j & 0x33333333) + ((j >> 2) & 0x33333333);
            j = (((j + (j >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
            return i == j;
        }
    }
    public class Program
    {
        public bool CanSortArray(List<int> nums)
        {
            BitComparer bc = new BitComparer();
            if (isSorted(nums)) return true;
            nums.Sort(bc);
            if (isSorted(nums)) return true;
            return false;
        }

        public bool isSorted(List<int> nums)
        {
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i - 1] > nums[i]) return false;
            }
            return true;
        }

        public static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine(obj.CanSortArray(Globals.nums));
            Console.WriteLine(obj.CanSortArray(Globals.nums2));
            Console.WriteLine(obj.CanSortArray(Globals.nums3));
            return;
        }
    }
}