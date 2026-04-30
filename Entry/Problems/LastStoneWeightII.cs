using System;
using System.Collections.Generic;

namespace _1049
{
    public static class Globals
    {
        public static int[] stones = { 2, 7, 4, 1, 8, 1 };
    }
    public class Program
    {
        public int LastStoneWeightII(int[] stones)
        {
            bool[] dp = new bool[1501];
            dp[0] = true;
            int sumStones = 0;
            foreach (int stone in stones)
            {
                sumStones += stone;
                for (int i=Math.Min(1500, sumStones); i>=stone; i--)
                    dp[i] |= dp[i - stone];
            }

            for (int i=sumStones / 2; i>=0; i--)
                if (dp[i]) return sumStones - i - i;
            return 0;
        }
    }
}
