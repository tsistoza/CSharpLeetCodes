// LeetCode 1524
using System;
using System.Collections.Generic;

namespace _1524
{
    public static class Globals
    {
        public static int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
    }
    public class Program
    {
        public int NumOfSubarrays(int[] arr)
        {
            int n = arr.Length;
            int mod = (int)Math.Pow(10, 9) + 7;
            int prefixSum = 0;
            int evenCount = 1, oddCount = 0;

            int subarraySumOdd = (oddCount > 0) ? 1 : 0;
            for (int i = 0; i < n; i++)
            {
                prefixSum += arr[i];

                if (prefixSum % 2 == 1)
                {
                    oddCount++;
                    subarraySumOdd = (subarraySumOdd + evenCount) % mod;
                }
                else
                {
                    evenCount++;
                    subarraySumOdd = (subarraySumOdd + oddCount) % mod;
                }

            }

            return subarraySumOdd % mod;
        }
    }
}
