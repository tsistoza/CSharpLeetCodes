// LeetCode 42
using System;
using System.Collections.Generic;



namespace _42
{
    public static class Globals
    {
        public static int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
    }
    public class Program
    {
        public int Trap(int[] height)
        {
            int totalWater = 0;
            int leftPtr = 0;
            int rightPtr = height.Length - 1;
            int leftMax = height[leftPtr];
            int rightMax = height[rightPtr];

            while (leftPtr < rightPtr)
            {
                int waterAtPtr = 0;
                if (leftMax <= rightMax)
                {
                    leftPtr++;
                    leftMax = (leftMax > height[leftPtr]) ? leftMax : height[leftPtr];
                    waterAtPtr += leftMax - height[leftPtr];
                }
                else
                {
                    rightPtr--;
                    rightMax = (rightMax > height[rightPtr]) ? rightMax : height[rightPtr];
                    waterAtPtr += rightMax - height[rightPtr];
                }
                totalWater += waterAtPtr;
            }
            return totalWater;
        }
    }
}
