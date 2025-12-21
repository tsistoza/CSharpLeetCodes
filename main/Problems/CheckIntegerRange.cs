// LeetCode 1893
using System;
using System.Collections.Generic;

namespace _1893
{
    public static class Globals
    {
        public static int[,] ranges = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        public static int left = 2;
        public static int right = 5;
    }
    public class Program
    {
        public bool IsCovered(int[,] ranges, int left, int right)
        {
            int ptr = left;
            for (int i=0; i<ranges.GetLength(0); i++)
            {
                for(int j = ranges[i,0]; j <= ranges[i,1]; j++)
                {
                    if (ptr > ranges[i, 1]) break;
                    if (ptr == j) ptr++;
                    if (ptr == right + 1) return true;
                }
            }
            if (ptr == right+1) return true;
            return false;
        }
    }
}