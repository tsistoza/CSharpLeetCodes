// LeetCode 2413
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 1;
    public static int n1 = 5;
    public static int n2 = 6;
    public static int n3 = 150;
}

namespace Solution
{
    public class Program
    {
        public int SmallestEvenMultiple(int n)
        {
            if (n % 2 == 1) return n * 2;
            return n;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.SmallestEvenMultiple(Globals.n));
            Console.WriteLine(obj.SmallestEvenMultiple(Globals.n1));
            Console.WriteLine(obj.SmallestEvenMultiple(Globals.n2));
            Console.WriteLine(obj.SmallestEvenMultiple(Globals.n3));
            return;
        }
    }
}