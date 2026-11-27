// LeetCode 2295
using System;
using System.Collections.Generic;
using System.Globalization;

namespace _2295
{
    public static class Globals
    {
        public static int[] nums = { 1, 2, 4, 6 };
        public static int[][] operations =
        {
            new int[2] { 1, 3 },
            new int[2] { 4, 7 },
            new int[2] { 6, 1 }
        };
        
    }

    public class Program
    {
        private void PrettyPrint(int[] result)
        {
            Console.Write("{ ");
            foreach (int num in result) Console.Write($"{num} ");
            Console.WriteLine("}\n\n");
        }
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
        public int[] ArrayChangeI(int[] nums, int[][] operations)
        {
            int[] map = new int[1000001];
            for (int i = 0; i < nums.Length; i++) map[nums[i]] = i;
            
            for (int i=0; i<operations.GetLength(0); i++)
            {
                int originalNumber = operations[i][0], numToReplace = operations[i][1];
                int index = map[originalNumber];
                nums[index] = numToReplace;
                map[originalNumber] = -1;
                map[numToReplace] = index;
            }

            PrettyPrint(nums);
            return nums;
        }
    }
}