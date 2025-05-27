// LeetCode 2894
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 5;
    public static int m = 1;
}

namespace Solution
{
    public class Program
    {
        public int DifferenceOfSums(int n, int m)
        {
            int num1 = 0, num2 = 0;

            for (int i=1; i<=n; i++)
            {
                if (i % m != 0) num1 += i;
                if (i % m == 0) num2 += i;
            }

            return num1 - num2;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.DifferenceOfSums(Globals.n, Globals.m));
            return;
        }
    }
}