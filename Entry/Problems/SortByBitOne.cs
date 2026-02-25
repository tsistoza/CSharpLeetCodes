// LeetCode 1356
using System;
using System.Collections.Generic;
using System.Text;

namespace _1356
{
    public static class Globals
    {
        public static int[] arr = { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
    }
    public class Compare : IComparer<int>
    {
        private int CountSetBits(int num)
        {
            int count = 0, copyNum = num;
            while (copyNum > 0)
            {
                copyNum &= (copyNum - 1);
                count++;
            }
            return count;
        }
        int IComparer<int>.Compare(int x, int y)
        {
            if (CountSetBits(x) < CountSetBits(y)) return -1;
            if (CountSetBits(x) > CountSetBits(y)) return 1;

            if (x < y) return -1;
            if (x > y) return 1;

            return 0;
        }
    }
    public class Program
    {
        private void PrettyPrint(int[] arr)
        {
            Console.Write("Array: { ");
            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine("}\n");
        }
        public int[] SortByBits(int[] arr)
        {
            int[] copyArr = new int[arr.Length];
            Array.Copy(arr, copyArr, arr.Length);

            Array.Sort(copyArr, new Compare());
            PrettyPrint(copyArr);
            return copyArr;
        }
    }
}
