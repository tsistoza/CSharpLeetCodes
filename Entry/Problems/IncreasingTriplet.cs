// LeetCode 334
using System;
using System.Collections.Generic;

namespace _334
{
    public static class Globals
    {
        public static List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };
    }
    public class Program
    {
        public bool IncreasingTriplet(List<int> nums)
        {
            for (int i=0,j=i+1,k=j+1; k<nums.Count; i++,k++,j++)
                if (nums[i] < nums[j] && nums[j] < nums[k]) return true;
            return false;
        }
    }
}