// LeetCode 128
using System;

public static class Globals
{
    public static int[] nums = { 100, 4, 200, 1, 3, 2 };
    public static int[] nums2 = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
}

namespace Solution
{
    public class Program
    {
        public int LongestConsecutive(int[] nums)
        {
            int sum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            
            foreach (int i in nums)
            {
                if (map.ContainsKey(i)) continue;
                map.Add(i, i + 1);
            }

            foreach (int i in nums)
            {
                int key = i;
                int tempSum = 0;
                while (map.ContainsKey(key))
                {
                    tempSum++;
                    key++;
                }
                sum = (sum < tempSum) ? tempSum : sum;
            }
            return sum;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.LongestConsecutive(Globals.nums));
            Console.WriteLine(obj.LongestConsecutive(Globals.nums2));
            return;
        }
    }
}