// LeetCode 1626
using System;
using System.Collections.Generic;

namespace _1626
{
    public static class Globals
    {
        public static int[] scores = { 1, 2, 3, 5 };
        public static int[] ages = { 8, 9, 10, 1 };
    }
    public class Program
    {
        public int BestTeamScore(int[] scores, int[] ages)
        {
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            for (int i=0; i<scores.Length; i++)
                queue.Enqueue(i, ages[i]);
            List<List<int>> dp = new List<List<int>>();
            dp = Enumerable.Repeat(new List<int>() { 0, 0, 0, 0 }, scores.Length).ToList();

            int prevIndex = queue.Dequeue();
            dp[0][0] = scores[prevIndex]; // PICK
            dp[0][1] = 0; // NOPICK
            dp[0][2] = scores[prevIndex]; // Youngest Player max score
            dp[0][3] = ages[prevIndex]; // Youngest Age

            int index = 1;
            while (queue.Count > 0)
            {
                int currIndex = queue.Dequeue();
                if (dp[index - 1][3] < ages[currIndex] && dp[index - 1][2] > scores[currIndex]) // Check if conflict (younger player scores more)
                {
                    //Console.WriteLine("Conflict");
                    dp[index][0] = scores[currIndex];
                    dp[index][1] = Math.Max(dp[index - 1][0], dp[index - 1][1]);
                    dp[index][2] = scores[currIndex];
                    dp[index][3] = ages[currIndex];
                } else
                {
                    dp[index][0] = Math.Max(dp[index - 1][0], dp[index - 1][1]) + scores[currIndex];
                    dp[index][1] = dp[index][0];
                    if (scores[currIndex] > dp[index - 1][2] && ages[currIndex] == dp[index - 1][3]) // Update youngest score, and age
                    {
                        dp[index][2] = scores[currIndex];
                        dp[index][3] = ages[currIndex];
                    }
                }

                //Console.WriteLine($"dp[{index}][0] = {dp[index][0]}, dp[{index}][1] = {dp[index][1]}, dp[{index}][2] = {dp[index][2]}");
                index++;
            }

            return Math.Max(dp[scores.Length - 1][0], dp[scores.Length - 1][1]);
        }
    }
}
