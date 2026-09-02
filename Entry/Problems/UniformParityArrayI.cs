using System;
using System.Collections.Generic;

namespace _3875
{
    public static class Globals
    {
        public static int[] nums1 = { 2, 3 };
    }
    public class Program
    {
        public bool UniformArray(int[] nums1)
        {
            HashSet<int> evens = new HashSet<int>();
            HashSet<int> odds = new HashSet<int>();
            for (int i=0; i<nums1.Length; i++)
            {
                if (nums1[i] % 2 == 0 && !evens.Contains(i)) evens.Add(i);
                if (nums1[i] % 2 == 1 && !odds.Contains(i)) odds.Add(i);
            }

            if (evens.Count == nums1.Length) return true;
            if (odds.Count == nums1.Length) return true;

            // Its always possible to create a Uniform Parity Array

            return true;
        }
    }
}
