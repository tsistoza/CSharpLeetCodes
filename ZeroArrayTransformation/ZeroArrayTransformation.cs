// LeetCode 3355
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 4, 3, 2, 1 };
    public static int[,] queries = { { 1, 3 }, { 0, 2 } };
}

namespace Solution
{
    public class Program
    {
        public bool isZeroArray(int[] nums, int[,] queries)
        {
            for (int i=0; i<queries.GetLength(0); i++)
            {
                for (int j = queries[i,0]; j <= queries[i,1]; j++)
                {
                    if (nums[j] == 0) continue;
                    nums[j]--;
                }
            }

            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != 0) return false;
            return true;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.isZeroArray(Globals.nums, Globals.queries));
            return;
        }
    }
}