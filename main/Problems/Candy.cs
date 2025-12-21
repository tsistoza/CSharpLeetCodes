// LeetCode 135
using System;
using System.Collections.Generic;

namespace _135
{
    public static class Globals
    {
        public static int[] ratings = { 60, 80, 100, 100, 100, 100, 100 };
    }
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
    }
}