// LeetCode 3411
using System;
using System.Collections.Generic;

namespace _3411
{
    public static class Globals
    {
        public static int[] nums = { 1, 2, 1, 2, 1, 1, 1 };
    }
    public class Program
    {
        private int gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
        private int lcm(int currLCM, int b, int gcdOfAandB)
        {
            return (currLCM * b) / gcdOfAandB;
        }
        public int MaxLength(int[] nums)
        {
            int n = nums.Length;

            int max = 1;
            for (int start=0; start<n; start++)
            {
                int product = nums[start];
                int currGcd = nums[start];
                int currLCM = nums[start];
                for (int end=start+1; end<n; end++)
                {
                    product *= nums[end];
                    currGcd = gcd(currGcd, nums[end]);
                    currLCM = lcm(currLCM, nums[end], gcd(currLCM, nums[end]));

                    Console.WriteLine($"Product = {product}, currGcd = {currGcd}, currLCM = {currLCM}, start = {start}, end = {end}");
                    int size = end - start + 1;
                    if (product == (currLCM * currGcd)) max = (max < size) ? size : max;
                }
            }

            return max;
        }
    }
}
