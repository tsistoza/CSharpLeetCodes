// LeetCode 2300
using System;
using System.Collections.Generic;

namespace _2300
{
    public static class Globals
    {
        public static int[] spells = { 3, 1, 2 };
        public static int[] potions = { 8, 5, 8 };
        public static long success = 16;
    }
    public class Program
    {
        private void PrettyPrint(int[] ans)
        {
            Console.Write("{ ");
            foreach (int i in ans) Console.Write($"{i} ");
            Console.Write("}\n\n");
        }
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Array.Sort(potions);
            int[] ans = new int[spells.Length];

            for (int i=0; i<spells.Length; i++)
            {
                int low = 0, high = potions.Length - 1;

                while (low < high)
                {
                    int mid = low + (high - low) / 2;
                    if ((long)(potions[mid] * spells[i]) >= success)
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                if (potions[low] * spells[i] < success) low++;
                
                ans[i] = potions.Length - low;
            }

            return ans;
        }
    }
}
