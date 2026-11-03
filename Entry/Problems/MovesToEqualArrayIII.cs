// LeetCode 3736
using System;
using System.Collections.Generic;

namespace _3736
{
    public class Program
    {
        public int MinMoves(int[] nums)
        {
            int max = int.MinValue;
            for (int i=0; i<nums.Length; i++)
                max = (max < nums[i]) ? nums[i] : max;

            int moves = 0;
            for (int i=0; i<nums.Length; i++)
                moves += Math.Abs(nums[i] - max);

            return moves;
        }
    }
}
