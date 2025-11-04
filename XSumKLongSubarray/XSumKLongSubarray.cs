// LeetCode 3318
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Solution
{
    public static class Globals
    {
        public static int[] nums = { 3, 8, 7, 8, 7, 5 };
        public static int k = 2;
        public static int x = 2;
    }

    public class Cmp : IComparer<(int freq, int key)>
    {
        public int Compare((int freq, int key) x, (int freq, int key) y)
        {
            if (x.freq > y.freq) return -1;
            if (x.freq < y.freq) return 1;
            if (x.key > y.key) return -1;
            if (x.key < y.key) return 1;
            return 0;
        }
    }

    public class Program
    {
        public int[] FindXSum(int[] nums, int k, int x)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            Cmp cmp = new Cmp();
            PriorityQueue<int, (int freq, int key)> queue = new PriorityQueue<int, (int freq, int key)>(cmp);
            int[] result = new int[nums.Length - k + 1];

            int i = 0;
            for (; i<k; i++)
                if (!count.TryAdd(nums[i], 1)) count[nums[i]]++;
            FindSum(ref nums, ref count, ref queue, ref result, 0, x);


            for (int index=1; i<nums.Length; i++, index++)
            {
                if (!count.TryAdd(nums[i], 1)) count[nums[i]]++;
                count[nums[i - k]]--;
                if (count[nums[i - k]] == 0) count.Remove(nums[i - k]);
                FindSum(ref nums, ref count, ref queue, ref result, index, x);
            }
            
            return result;
        }
        private void FindSum(ref int[] nums, ref Dictionary<int,int> count, 
                             ref PriorityQueue<int, (int freq, int key)> queue, ref int[] result, int index, int x)
        {
            queue.Clear();
            foreach (int key in count.Keys)
                queue.Enqueue(key * count[key], (count[key], key));
            int sum = 0;
            for (int i = 0; i < x; i++)
                sum += queue.Dequeue();
            result[index] = sum;
            return;
        }
        private static void PrettyPrint(int[] result)
        {
            Console.Write("{ ");
            for (int i=0; i<result.Length; i++)
            {
                if (i == result.Length-1) Console.Write($"{result[i]} ");
                else Console.Write($"{result[i]}, ");
            }
            Console.WriteLine("}");
            return;
        }
        public static void Main()
        {
            Program obj = new Program();
            Program.PrettyPrint(obj.FindXSum(Globals.nums, Globals.k, Globals.x));
            return;
        }
    }
}