// LeetCode 3314
using System;
using System.Collections.Generic;

public static class Globals
{
    public static readonly List<int> nums = new List<int>() { 2, 3, 5, 7 };
    public static readonly List<int> nums1 = new List<int>() { 11, 13, 31 };
}

namespace Solution
{
    public class Program
    {
        public IEnumerable<int> MinBitwiseArray(List<int> nums)
        {
            int[] result = new int[nums.Count];
            Array.Fill<int>(result, -1);
            List<int> bits = new List<int>();

            for (int i=0; i<nums.Count; i++)
            {
                this.getAllBits(bits, nums[i]);
                if (bits[0] == 0) // if zeroth bit is zero then its impossible to find a ans[i] such that ans[i] + ans[i]+1 == nums[i]
                {
                    result[i] = -1;
                    bits.Clear();
                    continue;
                }

                // Special case where nums[i] = 111 -> ans[i] = 11 | 100 (we will say 11 is the minimum)
                // We want to start at the minimum amount, in this case 11 is the min, this applies to any number as long as zeroth bit != 0
                // Suppose 1010 then our min is 111, similarly 11000, min = 1111, thus for n bits, the minimum is always n-1 bits where each bit is 1.

                int range = 0;
                for (int j = 0; j < bits.Count-1; j++) range += (int)Math.Pow(2, j);  // Find range which is the min amount
                while ((nums[i] != (range | range+1)) && range < nums[i]) range++;    // Find range in which range|range+1 == nums[i] but also range < nums[i]
                result[i] = range;
                bits.Clear();
            }
            return result;
        }

        private void getAllBits(List<int> bits, int val)
        {
                int numBits = (int)Math.Log2(val)+1;
                for (int j=0; j<numBits; j++)
                {
                    int bit = (val >> j) & 1; // get jth bit
                    bits.Add(bit);
                }
            return;
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();

            // Test Case 1
            Console.Write("Result: ");
            foreach (int i in obj.MinBitwiseArray(Globals.nums))
                Console.Write($"{i} ");
            Console.WriteLine();

            // Test Case 2
            Console.Write("Result: ");
            foreach (int i in obj.MinBitwiseArray(Globals.nums1))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}