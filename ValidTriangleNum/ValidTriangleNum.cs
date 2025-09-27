// LeetCode 611
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 2, 2, 3, 4 };
}

namespace Solution
{
    public class Program
    {
        public int TriangleNumber(int[] nums)
        {
            int numTriplets = 0;
            Array.Sort(nums);
            
            for (int i=nums.Length-1; i > 1; i--)
            {
                int left = 0, right = i - 1;
                while (left < right)
                {
                    if (nums[left] + nums[right] > nums[i])
                    {
                        numTriplets += (right - left);
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }
            

            return numTriplets;
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.TriangleNumber(Globals.nums));
            return;
        }
    }
}