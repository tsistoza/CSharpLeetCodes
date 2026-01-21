// LeetCode 3315
using System;
using System.Collections.Generic;

namespace _3315
{
    public static class Globals
    {
        public static List<int> nums = new List<int>(){ 2, 3, 5, 7 };
    }
    public class Program ()
    {
        public static void PrettyPrint(int[] results)
        {
            Console.Write("{ ");
            for(int i=0; i<results.Length; i++)
            {
                Console.Write(results[i]);
                if (i < results.Length - 1) Console.Write(", ");
            }
            Console.WriteLine(" }\n");
            return;
        }
        public int[] MinBitwiseArray(List<int> nums)
        {
            int[] results = new int[nums.Count];

            for (int i=0; i<nums.Count; i++)
            {
                int ans = nums[i], num = 0;
                int bit = ans & 1;
                int multiplicand = 1;
                while (bit > 0)
                {
                    num += multiplicand * bit;
                    ans >>= 1;
                    bit = ans & 1;
                    multiplicand *= 2;
                }

                num -= (multiplicand / 2); // Zero the leading bit

                while (ans > 0)
                {
                    num += multiplicand * bit;
                    ans >>= 1;
                    bit = ans & 1;
                    multiplicand *= 2;
                }

                results[i] = ((num | (num + 1)) == nums[i]) ? num : -1;
            }
            
            return results;
        }
    }

}