// LeetCode 1497
using System;
using System.Collections.Generic;

namespace _1497
{
    public static class Globals
    {
        public static int[] arr = { 1, 2, 3, 4, 5, 10, 6, 7, 8, 9 };
        public static int k = 5;
    }

    public class Program
    {
        public bool CanArrange(int[] arr, int k)
        {
            Dictionary<int,int> modPairs = new Dictionary<int,int>();
            for (int i=0; i<arr.Length; i++)
            {
                if (modPairs.ContainsKey(arr[i] % k)) modPairs[arr[i] % k]++;
                else modPairs.Add(arr[i] % k, 1);
            }

            foreach (int i in modPairs.Keys)
            {
                if (i == 0 && modPairs[i] % 2 > 0) return false;
                else if (i == 0 && modPairs[i] % 2 == 0) continue;

                if (!modPairs.ContainsKey(k - i)) return false;
                if (modPairs[i] != modPairs[k - i]) return false;
            }

            return true;
        }
    }
}