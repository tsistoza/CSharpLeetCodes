// LeetCodew 3186
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] power = { 1, 1, 3, 4 };
}

namespace Solution
{
    public class Program
    {
        public long MaximumTotalDamage(int[] power)
        {
            SortedDictionary<int, int> unique = new SortedDictionary<int, int>();
            unique.Add(int.MinValue, 0);
            foreach (int i in power)
            {
                if (!unique.TryAdd(i, 1))
                    unique[i]++;
            }

            List<int> sorted = new List<int>(unique.Keys);
            long[] dp = new long[unique.Count];
            long max = 0;
            int j = 1;
            for (int i=1; i<dp.Length; i++)
            {
                while (j<i && sorted[j] < sorted[i] - 2)
                {
                    max = Math.Max(max, dp[j]);
                    j++;
                }

                dp[i] = max + (1 * sorted[i] * unique[sorted[i]]);
            }

            for (; j < dp.Length; j++) max = Math.Max(max, dp[j]);
            return max;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaximumTotalDamage(Globals.power));
            return;
        }
    }
}