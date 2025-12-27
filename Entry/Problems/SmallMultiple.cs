// LeetCode 2413
using System;
using System.Collections.Generic;

namespace _2413
{
    public static class Globals
    {
        public static int n = 1;
    }
    public class Program
    {
        public int SmallestEvenMultiple(int n)
        {
            if (n % 2 == 1) return n * 2;
            return n;
        }
    }
}
