// LeetCode 1780
using System;
using System.Collections.Generic;

namespace _1780
{
    public static class Globals
    {
        public static int n = 12;
    }
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
    }
}
