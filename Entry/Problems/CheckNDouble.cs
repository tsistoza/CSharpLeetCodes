// LeetCode 1346
using System;
using System.Collections.Generic;

namespace _1346
{
    public static class Globals
    {
        public static int[] arr = new int[4] { 10, 2, 5, 3 };
    }

    public class Program
    {
        public bool CheckIfExist(int[] arr)
        {
            Dictionary<int, int> kvp = new Dictionary<int, int>();
            for (int i=0; i<arr.Length; i++)
            {
                kvp.Add(arr[i]*2, i);
                for (int j=i+1; j<arr.Length; j++)
                {
                    if (kvp.ContainsKey(arr[i])) return true;
                    if (arr[i] == 2 * arr[j]) return true;
                }
            }
            return false;
        }
    }
}