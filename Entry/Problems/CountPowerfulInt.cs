// LeetCode 2999
using System;
using System.Collections.Generic;

namespace _2999
{
    public static class Globals
    {
        public static long start = 1000;
        public static long finish = 2000;
        public static int limit = 4;
        public static string s = "3000";
    }
    public class Program
    {
        private long solve(string num, int n, long ub, long lb, int limit)
        {
            long count = 0;
            long strNum = Convert.ToInt64(num);
            //Console.WriteLine(strNum);
            if (strNum <= ub && strNum >= lb) count++;
            if (n < 0) return 0;

            for (int i=1; i<limit+1; i++)
            {
                string newNum = Convert.ToString(i) + num;
                count += solve(newNum, n - 1, ub, lb, limit);
            }

            return count;
        }
        public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            return solve(s, finish.ToString().Length-s.Length, finish, start, limit);
        }
    }
}