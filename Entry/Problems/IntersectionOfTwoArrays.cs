// LeetCode 349
using System;
using System.Collections.Generic;

namespace _349
{
    public static class Globals
    {
        public static int[] nums1 = { 4, 9, 5 };
        public static int[] nums2 = { 9, 4, 9, 8, 4 };
    }
    public class Program
    {
        private (int[], int[]) SmallerArray(ref int[] array1, ref int[] array2)
        {
            if (array1.Length > array2.Length) return (array1, array2);
            else return (array2, array1);
        }

        private bool SearchTarget(int[] array, HashSet<int> set, int target)
        {
            if (set.Contains(target)) return false;
            int low = 0, high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (array[mid] < target)
                    low = mid + 1;
                else if (array[mid] > target)
                    high = mid - 1;
                else
                {
                    set.Add(array[mid]);
                    return true;
                }
            }

            return false;
        }
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            (int[] bigArray, int[] smallArray) = SmallerArray(ref nums1, ref nums2);
            List<int> answer = new List<int>();
            HashSet<int> set = new HashSet<int>();

            Array.Sort(bigArray);
            for (int i=0; i<smallArray.Length; i++)
            {
                if (SearchTarget(bigArray, set, smallArray[i]))
                    answer.Add(smallArray[i]);
            }

            return answer.ToArray();
        }
    }
}
