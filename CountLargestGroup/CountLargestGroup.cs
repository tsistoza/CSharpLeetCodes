// LeetCode 1399
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 2;
}

namespace Solution
{
    public class Program
    {
        private int digitSum(int x)
        {
            int sum = 0;
            while(x > 0)
            {
                sum += x % 10;
                x /= 10;
            }

            return sum;
        }
        public int CountLargestGroup(int n)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            int maxSize = 0;
            int number = 0;
            for (int i=1; i<n+1; i++)
            {
                int sum = i;
                if (i >= 10) sum = digitSum(i);
                if (!count.TryAdd(digitSum(i), 1))
                    count[sum]++;
                if (count[sum] > maxSize) number = 1;
                if (count[sum] == maxSize) number++;   
                maxSize = Math.Max(maxSize, count[sum]);
            }
            return number;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CountLargestGroup(Globals.n));
            return;
        }
    }
}