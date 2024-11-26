// LeetCode 334
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };
    public static List<int> nums1 = new List<int>() { 5, 4, 3, 2, 1 };
    public static List<int> nums2 = new List<int>() { 2, 1, 5, 0, 4, 6 };
}

namespace Solution
{
    public class Program
    {
        public bool IncreasingTriplet(List<int> nums)
        {
            for (int i=0,j=i+1,k=j+1; k<nums.Count; i++,k++,j++)
                if (nums[i] < nums[j] && nums[j] < nums[k]) return true;
            return false;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.IncreasingTriplet(Globals.nums));
            Console.WriteLine(obj.IncreasingTriplet(Globals.nums1));
            Console.WriteLine(obj.IncreasingTriplet(Globals.nums2));
            return;
        }
    }
}