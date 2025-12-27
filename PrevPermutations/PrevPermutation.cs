// LeetCode 1053
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] arr = { 3, 2, 1 };
    public static int[] arr1 = { 1, 1, 5 };
    public static int[] arr2 = { 1, 9, 4, 6, 7 };
}

namespace Solution
{
    public class Compare : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            if (x < y) return 1;
            if (x > y) return -1;
            return 0;
        }
    }

    public class Program
    {
        public void swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
            return;
        }

        public int[] PrevPermOpt1(int[] arr)
        {
            if (arr.Length == 1) return arr;
            Compare cmp = new Compare();
            List<int> reverse = new List<int>(arr);
            reverse.Sort(cmp);
            bool flag = true;
            for (int i=0; i<reverse.Count; i++)
            {
                if (reverse[i] != arr[i]) {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                swap(arr, arr.Length - 1, arr.Length - 2);
                return arr;
            }

            reverse.Sort();
            SortedDictionary<int, List<int>> index = new SortedDictionary<int, List<int>>();
            for (int i=0; i<arr.Length; i++)
            {
                if (index.ContainsKey(arr[i])) index[arr[i]].Add(i);
                else index.Add(arr[i], new List<int>() { i });
            }

            for (int i=0,j=reverse.Count-1; i<reverse.Count && j>=0;)
            {
                if (reverse[i] == arr[i])
                {
                    i++;
                    continue;
                }
                if (arr[i] == reverse[j])
                {
                    j--;
                    continue;
                }
                swap(arr, index[reverse[j]].Last(), i);
                break;
            }
            return arr;
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach (int i in obj.PrevPermOpt1(Globals.arr))
                Console.Write($"{i} ");
            Console.WriteLine();

            foreach (int i in obj.PrevPermOpt1(Globals.arr1))
                Console.Write($"{i} ");
            Console.WriteLine();
            
            foreach (int i in obj.PrevPermOpt1(Globals.arr2))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
    
}