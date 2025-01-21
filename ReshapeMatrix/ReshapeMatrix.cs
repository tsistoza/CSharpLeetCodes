// LeetCode 566
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] mat = { { 1, 2 }, { 3, 4 } };
    public static int r = 1;
    public static int c = 4;
    public static int r1 = 2;
    public static int c1 = 4;
}

namespace Solution
{
    public class Program
    {
        public int[,] MatrixReshape(int[,] mat, int r, int c)
        {
            if (r == mat.GetLength(0) && c == mat.GetLength(1)) return mat;
            if (r * c != mat.Length) return mat;

            int[,] result = new int[r, c];

            int row = 0, col = 0;
            foreach (int i in mat)
            {
                result[row, col] = i;
                if (row >= result.GetLength(0)) row = 0;
                col++;
                if (col >= result.GetLength(1))
                {
                    col = 0;
                    row++;
                }
            }
            return result;
        }

        public void prettyPrintArr(int[,] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($" {arr[i, j]}, ");
                }
                Console.Write("}");
            }
            Console.WriteLine(" ]");
        }
        public static void Main()
        {
            Program obj = new Program();
            int[,] result = obj.MatrixReshape(Globals.mat, Globals.r, Globals.c);
            obj.prettyPrintArr(result);

            result = obj.MatrixReshape(Globals.mat, Globals.r1, Globals.c1);
            obj.prettyPrintArr(result);
            return;
        }
    }
}