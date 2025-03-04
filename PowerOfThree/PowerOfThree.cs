// LeetCode 1780
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 12;
    public static int n1 = 91;
    public static int n2 = 21;
}

namespace Solution
{
    public class Program
    {
        public bool checkPowersOfThree(int n)
        {
            int ternary = n % 3;
            int quotient = n;
            while (ternary != 2 && quotient > 3)
            {
                quotient = (int) (quotient/3);
                ternary = quotient % 3;
            }

            if (ternary == 2) return false;
            return true;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.checkPowersOfThree(Globals.n));
            Console.WriteLine(obj.checkPowersOfThree(Globals.n1));
            Console.WriteLine(obj.checkPowersOfThree(Globals.n2));
            return;
        }
    }
}