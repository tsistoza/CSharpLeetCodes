// LeetCode 1534
using System;
using System.Collections.Generic;

namespace _1534
{
    public static class Globals
    {
        public static int[] arr = { 1, 1, 2, 2, 3 };
        public static int a = 0;
        public static int b = 0;
        public static int c = 1;
    }

    public class Program
    {
        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int count = 0;
            for (int i=0; i<arr.Length-2; i++)
            {
                for (int j=i+1; j<arr.Length-1; j++)
                {
                    for (int k=j+1; k<arr.Length; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) > a) continue;
                        if (Math.Abs(arr[j] - arr[k]) > b) continue;
                        if (Math.Abs(arr[i] - arr[k]) > c) continue;
                        count++;
                    }
                }
            }
            return count;
        }
    }
}