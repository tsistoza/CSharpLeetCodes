// LeetCode 3354
using System;
using System.Collections.Generic;

namespace _3354
{
    public static class Globals
    {
        public static int[] nums = { 0 };
    }

    public class Program
    {
        public int CountValidSelections(int[] nums)
        {
            int sumRight = 0;
            for (int i=0; i<nums.Length; i++)
                sumRight += nums[i];

            int sumLeft = 0, selections = 0;
            for (int i=0; i<nums.Length; i++)
            {
                sumLeft += nums[i];
                sumRight -= nums[i];

                int difference = (int)MathF.Abs(sumRight - sumLeft);
                if (nums[i] == 0 && difference == 0)
                    selections += 2;
                if (nums[i] == 0 && difference == 1)
                    selections++;
            }
            return selections;
        }
    }
}
