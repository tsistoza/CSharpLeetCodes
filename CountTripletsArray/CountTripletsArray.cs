// LeetCode 2179
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums1 = { 4, 0, 1, 3, 2, 5 };
    public static int[] nums2 = { 4, 3, 0, 1, 5, 2 };
}

namespace Solution
{
    public class Program
    {
        public long GoodTriplets(int[] nums1, int[] nums2)
        {
            Dictionary<int,int> valToIdx1 = new Dictionary<int,int>();
            Dictionary<int,int> idx1ToIdx2 = new Dictionary<int,int>();

            for (int i=0; i<nums1.Length; i++) valToIdx1.TryAdd(nums1[i], i);
            for (int i=0; i<nums2.Length; i++) idx1ToIdx2.TryAdd(valToIdx1[nums2[i]], i);

            long count = 0;
            for (int i=0; i<nums1.Length; i++)
            {
                int index1 = valToIdx1[nums1[i]], index2 = idx1ToIdx2[valToIdx1[nums1[i]]];

                if (index1 < index2)
                    count += index1 * (nums1.Length-1 - index2);
                else
                    count += index2 * (nums1.Length-1 - index1);
            }

            return count;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.GoodTriplets(Globals.nums1, Globals.nums2));
            return;
        }
    }
}