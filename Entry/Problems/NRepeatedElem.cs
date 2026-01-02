// LeetCode 961
using System;
using System.Collections.Generic;

namespace _961
{
    public static class Globals
    {
        public static int[] nums = { 2, 1, 2, 5, 3, 2 };
    }
    public class Program
    {
        public int RepeatedNTimes(int[] nums)
        {
            int n = nums.Length / 2;
            int repeatedElem = -1;
            Dictionary<int, int> nRepeated = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!nRepeated.TryAdd(num, 1))
                    nRepeated[num]++;
                if (nRepeated[num] == n)
                {
                    repeatedElem = num;
                    break;
                }
            }
            return repeatedElem;
        }
    }
}
