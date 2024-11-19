// LeetCode 2275
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> candidates = new List<int>() { 16, 17, 71, 62, 24 };
    public static List<int> candidates2 = new List<int>() { 8, 8 };
    public static List<int> candidates3 = new List<int>() { 1, 5, 3 };
    public static List<int> candidates4 = new List<int>() { 7 };
}


namespace Solution
{
    public class Program
    {
        public static int LargestCombination(List<int> candidates)
        {
            List<int> nums = new List<int>();
            if (candidates.Count == 1) return 1;
            int[] dp = new int[candidates.Count];
            Array.Fill<int>(dp, 1);

            for(int i = 0; i < candidates.Count; i++)
            {
                nums.Add(candidates[i]);
                for(int j = 0; j < i; j++)
                {
                    if (bitwiseAndCheck(nums.GetEnumerator()) && dp[i] < dp[j] + 1)
                        nums.Add(candidates[j]);
                }
                dp[i] = nums.Count;
                nums.Clear();
            }
            return dp[candidates.Count-1];
        }

        public static bool bitwiseAndCheck(IEnumerator<int> enumer)
        {
            enumer.MoveNext();
            int ans = enumer.Current;
            while (enumer.MoveNext()) ans &= enumer.Current;
            if (ans > 0) return true;
            else return false;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(LargestCombination(Globals.candidates));
            Console.WriteLine(LargestCombination(Globals.candidates2));
            Console.WriteLine(LargestCombination(Globals.candidates3));
            Console.WriteLine(LargestCombination(Globals.candidates4));
            return;
        }
    }
}