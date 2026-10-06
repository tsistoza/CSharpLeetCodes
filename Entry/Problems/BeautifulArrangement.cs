// LeetCode 526
using System;
using System.Collections.Generic;

namespace _526
{
    public static class Globals
    {
        public static int n = 4;
    }
    public class Program
    {
        public int count = 0;

        private void PrettyPrint(int[] dp)
        {
            Console.Write("{ ");
            for (int i=0; i<dp.GetLength(0); i++)
            {
                Console.Write($"{dp[i]} ");
            }
            Console.WriteLine("}\n");
        }
        private void BuildPermutations(bool[] placed, int index, int num, int n)
        {
            if (index == n)
            {
                count++;
                return;
            }

            for (int i=1; i<=n; i++)
            {
                int nextIndex = index + 1;
                if (placed[i]) continue;
                if (nextIndex % i > 0 && i % nextIndex > 0) continue;

                placed[i] = true;
                BuildPermutations(placed, nextIndex, i, n);
                placed[i] = false;
            }
            return;
        }
        public int CountArrangement(int n)
        {
            bool[] placed = new bool[n + 1];
            BuildPermutations(placed, 1, 1, n);
            return count;
        }
    }
}
