// LeetCode 3658
using System;
using System.Collections.Generic;

namespace _3658
{
    public static class Globals
    {
        public static int n = 5;
    }
    public class Program
    {
        public int GcdOfOddEvenSums(int n)
        {
            int sumOdd = n * n; // sum of first odd n numbers = n^2
            int sumEven = n * (n + 1); // sum of first even n numbers = n(n+1)

            int dividend = 0, divisor = 0;
            if (sumOdd < sumEven)
            {
                dividend = sumEven;
                divisor = sumOdd;
            }
            else
            {
                dividend = sumOdd;
                divisor = sumEven;
            }

            int remainder = dividend % divisor;
            while (remainder > 0)
            {
                dividend = divisor;
                divisor = remainder;
                remainder = dividend % divisor;
            }

            return divisor;
        }
    }
}
