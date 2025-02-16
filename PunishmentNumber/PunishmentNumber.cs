// LeetCode 2698
using System;
using System.Collections.Generic;

public static class Globals
{
    public static readonly int n = 10;
    public static readonly int n1 = 37;
}

namespace Solution
{
    public class Program
    {
        private bool partition(int x, int target)
        {
            if (x == target) return true;
            if (x == 0) return target == 0;

            for (int i=10; i<Math.Min(x, 1000); i*=10)
                if (partition(x / i, target - x % i)) return true;
            return false;
        }
        public int punishmentNumber(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                int square = i * i;
                sum += (partition(square, i)) ? square : 0;
            }

            return sum;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.punishmentNumber(Globals.n));
            Console.WriteLine(obj.punishmentNumber(Globals.n1));
            return;
        }
    }
}