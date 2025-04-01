// LeetCode 2140
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] questions = { { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 } };
}

namespace Solution
{
    public class Program
    {
        public long MostPoints(int[,] questions)
        {
            long max = long.MinValue;
            long[] dp = new long[questions.Length];
            for (int i=questions.GetLength(0)-1; i>=0; i--)
            {
                if (i + questions[i, 1] + 1 >= questions.GetLength(0))
                {
                    dp[i] = questions[i, 0];
                    max = Math.Max(max, dp[i]);
                    continue;
                }

                dp[i] = questions[i, 0] + Math.Max(dp[i + questions[i, 1] + 1], dp[questions[i, 1] + 2]);
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MostPoints(Globals.questions));
            return;
        }
    }
}