// LeetCode 240
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public static class Globals
{
    public static int[,] matrix = { { 1, 4, 7, 11, 15 }, { 2, 5, 8, 12, 19 }, { 3, 6, 9, 16, 22 }, { 10, 13, 14, 17, 24 }, { 18, 21, 23, 26, 30 } };
    public static int target = 20;
}

namespace Solution
{
    public class Program
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            int row = 0;
            
            while (row < matrix.GetLength(0))
            {
                int low = 0;
                int high = matrix.GetLength(1)-1;
                int mid = 0;

                while (low < high && matrix[row, 0] <= target && matrix[row, matrix.GetLength(1)-1] >= target)
                {
                    mid = low + (high - low) / 2;
                    Console.WriteLine($"low = {low}, high = {high}, mid = {mid}, matrix[{row},{mid}] = {matrix[row, mid]}");
                    if (matrix[row, mid] < target) low = mid + 1;
                    if (matrix[row, mid] > target) high = mid - 1;
                }
                if (matrix[row, low] == target) return true;
                row++;
            }
            return false;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.SearchMatrix(Globals.matrix, Globals.target));
            return;
        }
    }
}