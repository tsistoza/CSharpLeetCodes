// LeetCode 2780
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> nums = new List<int>() { 1, 2, 2, 2 };
}

namespace Solution
{
    public class Program
    {
        public int MinimumIndex(List<int> nums)
        {
            Dictionary<int,int> dict1 = new Dictionary<int,int>();
            Dictionary<int,int> dict2 = new Dictionary<int,int>();

            for (int i=0; i<nums.Count; i++)
            {
                if (dict2.ContainsKey(nums[i])) dict2[nums[i]]++;
                else dict2.Add(nums[i], 1);
            }

            int count1 = 0;
            int count2 = nums.Count;
            int dominant = 0;
            for (int i=0; i<nums.Count; i++)
            {
                if (dict1.ContainsKey(nums[i])) dict1[nums[i]]++;
                else dict1.Add(nums[i], 1);

                if (i == 0) dominant = nums[i];
                else dominant = (dict1[nums[i]] < dict1[dominant]) ? dominant : nums[i];
                count1++;

                dict2[nums[i]]--;
                count2--;

                // Check if valid
                if ((float)dict1[dominant] / (float) count1 <= 0.5f || (float)dict2[dominant] / (float)count2 <= 0.5f) continue;
                return i;
            }

            return -1;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MinimumIndex(Globals.nums));
            return;
        }
    }
}