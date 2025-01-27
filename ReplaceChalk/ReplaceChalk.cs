// LeetCode 1894
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] chalk = { 5, 1, 5 };
    public static int k = 22;
    public static int[] chalk1 = { 3, 4, 1, 2 };
    public static int k1 = 25;
}

namespace Solution
{
    public class Program
    {
        public int ChalkReplacer(int[] chalk, int k)
        {
            int sum = 0;
            foreach (int i in chalk) sum += i;
            int remainder;
            if (sum < k) remainder = k % sum;
            else remainder = sum;

            for (int index=0; remainder > 0; index++)
            {
                remainder -= chalk[index];
                if (remainder <= 0) return index;
            }

            return 0;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.ChalkReplacer(Globals.chalk, Globals.k));
            Console.WriteLine(obj.ChalkReplacer(Globals.chalk1, Globals.k1));
            return;
        }
    }
}