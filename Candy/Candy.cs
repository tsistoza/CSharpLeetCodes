// LeetCode 135
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] ratings = { 60, 80, 100, 100, 100, 100, 100 };
}

namespace Solution
{
    public class Program
    {
        public int Candy(int[] ratings)
        {
            int sum = 1, lastCandy = 1;
            for (int i=1; i<ratings.Length; i++)
            {
                if (ratings[i - 1] == ratings[i])
                {
                    sum++;
                    lastCandy = 1;
                }
                if (ratings[i - 1] < ratings[i])
                {
                    lastCandy++;
                    sum += lastCandy;
                }

                if (ratings[i-1] > ratings[i] && lastCandy == 1)
                    sum += i + 1;
                if (ratings[i-1] > ratings[i] && lastCandy >= 2)
                    sum += lastCandy-- - 1;
            }
            return sum;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.Candy(Globals.ratings));
            return;
        }
    }
}