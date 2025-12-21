// LeetCode 2843
using System;
using System.Collections.Generic;

namespace _2843
{
    public static class Globals
    {
        public static int low = 1;
        public static int high = 100;
    }
    public class Program
    {
        private bool isSymmetric(int curr)
        {
            if (curr.ToString().Length % 2 == 1)
                return false;   
            string num = curr.ToString();
            int sum1 = 0, sum2 = 0;

            for (int i=0; i<num.Length/2; i++)
            {
                sum1 += num[i] - 48;
                sum2 += num[i + (num.Length / 2)] - 48;
            }

            return sum1 == sum2;
        }
        public int CountSymmetricIntegers(int low, int high)
        {
            int count = 0;
            int curr = low;

            while (curr <= high)
            {
                if (isSymmetric(curr))
                    count++;
                if (curr.ToString().Length % 2 == 1) curr = (int)Math.Pow(10, curr.ToString().Length);
                else curr++;
            }
            return count;
        }
    }
}
