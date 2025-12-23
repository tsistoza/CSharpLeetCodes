// LeetCode 1769
using System;
using System.Collections.Generic;

namespace _1769
{
    public static class Globals
    {
        public static string boxes = "110";
    }

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
    }
}