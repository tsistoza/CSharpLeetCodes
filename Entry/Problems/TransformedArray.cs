// LeetCode 3379
using System;
using System.Collections.Generic;
using System.Text;

namespace _3379
{
    public static class Globals
    {
        public static int[] nums = { 3, -2, 1, 1 };
    }
    public class Program
    {
        public static void PrettyPrint(int[] nums)
        {
            Console.Write("{ ");
            for(int i=0; i<nums.Length; i++)
            {
                if (i != nums.Length - 1)
                    Console.Write($"{i}, ");
                else
                    Console.Write($"{i} ");
            }
            Console.WriteLine("}\n");
            return;
        }

        public int[] ConstructTransformedArray(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    result[i] = nums[i];
                    continue;
                }

                int newIndex = i + nums[i];
                if (newIndex < 0)
                    result[i] = newIndex + nums.Length;
                else if (newIndex >= nums.Length)
                    result[i] = newIndex - nums.Length;
            }
            PrettyPrint(result);
            return result;
        }
    }
}
