// LeetCode 2099
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 3, 4, 3, 3 };
    public static int k = 2;
}

namespace Solution
{
    public class Program
    {

        public static void prettyPrint(int[] result)
        {
            Console.Write("{ ");
            foreach (int i in result)
                Console.Write($"{i} ");
            Console.WriteLine("}");
        }
        public class Compare : IComparer<int>
        {
            int IComparer<int>.Compare(int x, int y)
            {
                if (x < y) return 1;
                if (x > y) return -1;
                return 0;
            }
        }
        public int[] MaxSubsequence(int[] nums, int k)
        {
            Compare cmp = new Compare();
            PriorityQueue<int,int> queue = new PriorityQueue<int,int>(cmp);
            for (int i = 0; i < nums.Length; i++) queue.Enqueue(i, nums[i]);

            SortedSet<int> list = new SortedSet<int>();
            for (int j=k; j>0 && queue.Count > 0; j--)
                list.Add(queue.Dequeue());

            IEnumerator<int> enumerator = list.GetEnumerator();
            enumerator.MoveNext();

            int[] result = new int[k];
            for (int i=0; i<k; i++, enumerator.MoveNext())
                result[i] = nums[enumerator.Current];

            return result;
            
        }
        public static void Main()
        {
            Program obj = new Program();
            Program.prettyPrint(obj.MaxSubsequence(Globals.nums, Globals.k));
            return;
        }
    }
}