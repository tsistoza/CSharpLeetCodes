// LeetCode 2295
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 1, 2, 4, 6 };
    public static List<List<int>> operations = new List<List<int>>()
    {
        new List<int> { 1, 3 },
        new List<int> { 4, 7 },
        new List<int> { 6, 1 }
    };
    public static List<int> nums1 = new List<int>() { 1, 2 };
    public static List<List<int>> operations1 = new List<List<int>>()
    {
        new List<int> { 1, 3 },
        new List<int> { 2, 1 },
        new List<int> { 3, 2 }
    };
}

namespace Solution
{
    public class Program
    {
        public IEnumerable<int> ArrayChange (List<int> nums, List<List<int>> operations)
        {
            int[] changedArray = nums.ToArray ();
            Dictionary<int, int> map = new Dictionary<int, int>(); // Will use a map to store the index of a particular number
            for (int i = 0; i < nums.Count; i++)
                map.Add(nums[i], i); // key = number, value = index in nums

            foreach (List<int> operation in operations)
            {
                int index = map[operation[0]];
                changedArray[index] = operation[1];
                map.Add(operation[1], index);
                map.Remove(operation[0]);
            }

            return changedArray;
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach (int i in obj.ArrayChange(Globals.nums, Globals.operations))
                Console.Write($"{i} ");
            Console.WriteLine();
            foreach (int i in obj.ArrayChange(Globals.nums1, Globals.operations1))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}