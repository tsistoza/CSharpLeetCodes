using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] unsorted = { 38, 27, 43, 10 };
}

namespace Sort
{
    public class MergeSort
    {
        public void merge(int[] arr, int left, int mid, int right)
        {
            List<int> leftArr = new List<int>();
            List<int> rightArr = new List<int>();
            // Populate Arrays
            for (int i=left; i<=mid; i++) leftArr.Add(arr[i]);
            for (int i=mid+1; i<=right; i++) rightArr.Add(arr[i]);

            // Merge
            int index = left;
            for (int i=0, j=0; i<leftArr.Count || j<rightArr.Count;)
            {
                if (i == leftArr.Count || j == rightArr.Count)
                {
                    while (j < rightArr.Count) arr[index++] = rightArr[j++];
                    while (i < leftArr.Count) arr[index++] = leftArr[i++];
                    break;
                }

                if (leftArr[i] > rightArr[j])
                {
                    arr[index++] = rightArr[j++];
                    continue;
                }
                if (leftArr[i] < rightArr[j])
                {
                    arr[index++] = leftArr[i++];
                    continue;
                }

                // arr[i] == arr[j]
                arr[index++] = leftArr[i++];
                arr[index++] = rightArr[j++];
            }
            return;
        }
        public void Sort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int mid = left + (right-left) / 2;
            Sort(arr, left, mid);
            Sort(arr, mid + 1, right);
            merge(arr, left, mid, right);
            return;
        }
    }

}

namespace ExampleRun
{
    public class Program
    {
        public void prettyPrintArr(int[] arr)
        {
            Console.Write("Array: [");
            foreach (int i in arr)
                Console.Write($" {i}, ");
            Console.WriteLine("]");
            return;
        }
        public static void Main()
        {
            Program print = new Program();
            Sort.MergeSort obj = new Sort.MergeSort();
            print.prettyPrintArr(Globals.unsorted);
            obj.Sort(Globals.unsorted, 0, Globals.unsorted.Length-1);
            print.prettyPrintArr(Globals.unsorted);
            return;
        }
    }
}