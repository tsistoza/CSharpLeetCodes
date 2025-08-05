// LeetCode 904
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] fruits = { 1, 2, 3, 2, 2 };
}

namespace Solution
{
    public class Program
    {
        public int TotalFruit(int[] fruits)
        {
            int numFruits = 0;
            Stack<int> idx = new Stack<int>();
            Dictionary<int, int> baskets = new Dictionary<int, int>();
            for (int i=0, window=0, currFruits=0; i+window<fruits.Length;)
            {
                if (baskets.ContainsKey(fruits[i+window]))
                {
                    baskets[fruits[i + window]]++;
                } else
                {
                    idx.Push(i+window);
                    baskets.Add(fruits[i + window], 1);
                }

                currFruits++;
                window++;

                if (i+window >= fruits.Length)
                {
                    numFruits = Math.Max(currFruits, numFruits);
                    continue;
                }

                if (baskets.Count > 2)
                {
                    baskets.Clear();
                    idx.Pop();
                    i = idx.Peek();
                    baskets.Add(fruits[i], 1);
                    window = 1;
                    numFruits = Math.Max(currFruits-1, numFruits);
                    currFruits = 1;
                }
            }
            return numFruits;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.TotalFruit(Globals.fruits));
            return;
        }
    }
}