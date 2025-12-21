// LeetCode 2579
using System;
using System.Collections.Generic;

namespace _2579
{
    public static class Globals
    {
        public static int n = 5;
    }
    public class Program
    {
        private long recursion(int n)
        {
            if (n == 1) return 1;
            return recursion(n - 1) + (4*(n-1));
        }
        public long ColoredCells(int n)
        {
            if (n == 1) return 1;
            return recursion(n);
        }
    }
}