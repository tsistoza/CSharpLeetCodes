// LeetCode 2999
using System;
using System.Collections.Generic;

public static class Globals
{
    public static long start = 15;
    public static long finish = 215;
    public static int limit = 6;
    public static string s = "10";
}

namespace Solution
{
    public class Program
    {
        public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            long count = 0;
            long num = Convert.ToInt64(s);
            if (num >= start && num <= finish)
                count++;
            int exponent = s.Length - 1;
            while (num < finish)
            {
                int multiplicand = 1;
                exponent++;

                long temp = num;
                while (multiplicand < limit + 1)
                {
                    temp = num + (long)Math.Pow(10, exponent) * multiplicand++;
                    if (temp > finish ) break;
                    count++;
                }
                num += (long)Math.Pow(10, exponent);
            }
            return count;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.NumberOfPowerfulInt(Globals.start, Globals.finish, Globals.limit, Globals.s));
            return;
        }
    }
}