// LeetCode 1769
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string boxes = "110";
    public static string boxes1 = "001011";
}

namespace Solution
{
    public class Program
    {
        public int[] MinOperations(string boxes)
        {
            int[] result = new int[boxes.Length];
            
            for (int i=0; i<result.Length; i++)
            {
                for (int j=0; j<boxes.Length; j++)
                {
                    if (boxes[j] == '1')
                        result[i] += Math.Abs(j - i);
                }
            }
            return result;
        }
        public static void Main()
        {
            Program obj = new Program();
            foreach (int i in obj.MinOperations(Globals.boxes))
                Console.Write($"{i} ");
            Console.WriteLine();

            foreach (int i in obj.MinOperations(Globals.boxes1))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}