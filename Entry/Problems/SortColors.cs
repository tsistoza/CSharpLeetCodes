// LeetCode 75
using System;
using System.Collections.Generic;

namespace _75
{
    public static class Globals
    {
        public static int[] nums = { 2, 1, 2, 2, 2, 2, 0, 0, 0 };
    }
    public class Program
    {
        public static void prettyPrint(int[] nums)
        {
            Console.Write("{ ");
            foreach (int i in nums)
                Console.Write($"{i}, ");
            Console.WriteLine("}");
            return;
        }
        private void Swap(ref int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
            return;
        }
        public void SortColors(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int currPtr = 0;

            while (left < right && currPtr <= right)
            {
                prettyPrint(nums);
                if (nums[left] == 0)
                {
                    left++;
                    currPtr = left;
                    continue;
                }
                if (nums[right] == 2)
                {
                    right--;
                    continue;
                }

                Console.WriteLine($"left={left}, right={right}, currPtr={currPtr}");
                if (nums[currPtr] == 0)
                    Swap(ref nums, left, currPtr);
                else if (nums[currPtr] == 2)
                    Swap(ref nums, right, currPtr);
                else
                    currPtr++;
            }
            return;
        }
    }
}
