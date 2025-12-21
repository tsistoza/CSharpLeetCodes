// LeetCode 2523
using System;
using System.Collections.Generic;

namespace _2523
{
    public static class Globals
    {
        public static int left = 4;
        public static int right = 6;
    }

    public class Program
    {
        private static void prettyPrint(int[] arr)
        {
            Console.Write("{ ");
            for (int i=0; i< arr.Length; i++)
                Console.Write($"{arr[i]}, ");
            Console.WriteLine("}");
            return;
        }
        private bool isPrime(int num)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;

            if (num % 2 == 0 || num % 3 == 0) return false;
            for (int i = 5; i * i <= num; i += 6)
                if (num % i == 0 || num % (i + 2) == 0) return false;
            return true;
        }
        public int[] ClosestPrimes(int left, int right)
        {
            int[] prime = { -1, -1 };
            int i = left;
            for (; i<right; i++)
            {
                if (!isPrime(i)) continue;
                for (int j=i+1; j<=right; j++)
                {
                    if (!isPrime(j)) continue;
                    if (j - i < prime[1] - prime[0] || (prime[0] == -1 && prime[1] == -1))
                    {
                        prime[0] = i;
                        prime[1] = j;
                    }
                    i = j - 1;
                    break;
                }
            }
            
            return prime;
        }
    }
}