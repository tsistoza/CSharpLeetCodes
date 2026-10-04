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
                int low = 0, high = potions.Length - 1, currSpell = spells[i];

                while (low < high)
                {
                    int mid = low + (high - low) / 2;

                    if (potions[mid] >= (success + currSpell  - 1) / currSpell)
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                if (potions[low] < (success + currSpell - 1) / currSpell) low++;
                ans[i] = potions.Length - low;
            }

            return ans;
        }
    }
}
