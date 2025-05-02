// LeetCode 1295
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] nums = { 555, 901, 482, 1771 };
}

namespace Solution
{
    public class Program
    {
        public int FindNumbers(int[] nums)
        {
            int count = 0;
            foreach (int num in nums)
            {
                int temp = num;
                int numDigits = 0;
                while (temp > 0)
                {
                    temp /= 10;
                    numDigits++;
                }
                if (numDigits % 2 == 0) count++;
            }
            return count;
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.FindNumbers(Globals.nums));
            return;
        }
    }
}