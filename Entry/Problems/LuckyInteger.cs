// LeetCode 1394
using System;
using System.Collections.Generic;

namespace _1394
{
    public static class Globals
    {
        public static int[] arr = { 2, 2, 2, 3, 3 };
    }
    public class Program
    {
        public int findLucky(int[] arr)
        {
            Dictionary<int,int> freqs = new Dictionary<int,int>();
            foreach (int i in arr)
                if (!freqs.TryAdd(i, 1)) freqs[i]++;
            
            foreach (int key in freqs.Keys)
                if (freqs[key] == key) return key;

            return -1;
        }
    }
}