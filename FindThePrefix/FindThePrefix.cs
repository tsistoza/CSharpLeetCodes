// LeetCode 2657
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

public static class Globals
{
    public static int[] A = { 1, 3, 2, 4 };
    public static int[] B = { 3, 1, 2, 4 };
    public static int[] A1 = { 2, 3, 1 };
    public static int[] B1 = { 3, 1, 2 };
}

namespace Solution
{
    public class Program
    {
        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            int[] C = new int[A.Length];
            List<int> listA = new List<int>();
            List<int> listB = new List<int>();
            for (int i=0; i<A.Length; i++)
            {
                if (!listA.Contains(A[i])) listA.Add(A[i]);
                if (!listB.Contains(B[i])) listB.Add(B[i]);

                if (i == 0)
                {
                    if (A[i] == B[i]) C[i] = 1;
                    continue;
                }

                if (A[i] == B[i]) 
                { 
                    C[i] += C[i - 1]+1;
                    continue;
                }
                if (listA.Contains(B[i])) C[i]++;
                if (listB.Contains(A[i])) C[i]++;
                C[i] += C[i - 1];
            }
            return C;
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach (int i in obj.FindThePrefixCommonArray(Globals.A, Globals.B))
                Console.Write($"{i} ");
            Console.WriteLine();

            foreach (int i in obj.FindThePrefixCommonArray(Globals.A1, Globals.B1))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}