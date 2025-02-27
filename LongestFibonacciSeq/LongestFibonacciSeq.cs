// LeetCode 873
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public static int[] arr1 = { 1, 3, 7, 11, 12, 14, 18 };
}

namespace Solution
{
    public class Program
    {
        private void getFibonacciSubseq(List<int> subseq, ref int max, int[] arr, int index)
        {
            if (subseq.Count >= 3)
                max = (max < subseq.Count) ? subseq.Count : max;

            if (index > arr.Length) return;
            
            if (subseq.Count < 2)
            {
                if (index > arr.Length - 1) return;

                List<int> temp = new List<int>(subseq);
                temp.Add(arr[index]);
                getFibonacciSubseq(new List<int>(temp), ref max, arr, index + 1);

                if (subseq.Count == 0) return;

                temp = new List<int>(subseq);
                temp.RemoveAt(subseq.Count - 1);
                temp.Add(arr[index]);
                getFibonacciSubseq(new List<int>(temp), ref max, arr, index + 1);
                return;
            }

            int idx = Array.IndexOf(arr, subseq[subseq.Count - 2] + subseq[subseq.Count - 1], index);
            if (idx == -1) return;
            subseq.Add(arr[idx]);
            getFibonacciSubseq(new List<int>(subseq), ref max, arr, idx + 1);

            return;
        }
        public int LenLongestFibSubseq(int[] arr)
        {
            int max = 0;
            getFibonacciSubseq(new List<int>(), ref max, arr, 0);
            return max;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.LenLongestFibSubseq(Globals.arr));
            Console.WriteLine(obj.LenLongestFibSubseq(Globals.arr1));
            return;
        }
    }
}