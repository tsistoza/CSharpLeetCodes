// LeetCode 1346
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] arr = new int[4] { 10, 2, 5, 3 };
    public static int[] arr1 = new int[4] { 3, 1, 7, 11 };
}

namespace Solution
{
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
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CheckIfExist(Globals.arr));
            Console.WriteLine(obj.CheckIfExist(Globals.arr1));
            return;
        }
    }
}