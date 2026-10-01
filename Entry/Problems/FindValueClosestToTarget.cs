// LeetCode 1521
using System;
using System.Collections.Generic;

namespace _1521
{
    public static class Globals
    {
        public static int[] arr = { 2, 70, 41, 63, 60, 55, 51, 85, 60, 77, 56, 24, 66, 13, 91, 28, 31, 92, 79, 85 };
        public static int target = 33;
    }
    public class Program
    {
        private void PrettyPrint(int[][] table)
        {
            for (int i=0; i<table.Length; i++)
            {
                Console.Write("{ ");
                for (int j=0; j < table[0].Length; j++) 
                {
                    Console.Write($"{table[i][j]} ");
                }
                Console.WriteLine("}");
            }
        }
        private void build(int[][] table, int[] arr, int col, int target)
        {
            int row = table.GetLength(0);
            for (int i = 0; i < row; i++)
            {
                table[i] = new int[col];
                Array.Fill(table[i], -1);
                table[i][0] = arr[i];
            }
            for (int j = 1; j < col; j++)
            {
                for (int i = 0; (i + (1 << j) - 1) < row; i++)
                {
                    Console.Write($"arr[{i}] = {arr[i]} --> ");
                    int index = i + (1 << j-1);
                    table[i][j] = (table[i][j - 1] & table[index][j-1]);
                    Console.WriteLine($"table[{i},{j - 1}] = {table[i][j - 1]}, table[{index},{j - 1}] = {table[index][j-1]}");
                    Console.WriteLine($"table[{i},{j}] = {table[i][j]}");
                }
            }

            PrettyPrint(table);
            return;
        }

        private int query(int[][] table, int left, int right)
        {
            if (left == right) return table[left][0];

            uint ans = 0xFFFFFFFF;
            int k = (int)Math.Log2(right - left + 1);
            int leftBounds = left;
            int rightBounds = leftBounds + (1 << k) - 1;
            if (rightBounds == right) return table[left][k];

            while (leftBounds <= right)
            {
                ans &= (uint)table[leftBounds][k];
                leftBounds = rightBounds + 1;
                k = (int)Math.Log2(right - leftBounds + 1);
                rightBounds = leftBounds + (1 << k) - 1;
            }

            return (int)ans;
        }
        public int ClosestToTarget(int[] arr, int target)
        {
            int row = arr.Length, col = (int)Math.Log2(row) + 1;
            int[][] table = new int[row][];
            build(table, arr, col, target);

            int ans = int.MaxValue;
            int L = 0;
            while (L < row)
            {
                int low = L, high = row - 1;
                int currMinQuery = int.MaxValue;
                while (low < high)
                {
                    int mid = low + (high - low) / 2;
                    int curr = query(table, L, mid);
                    if (curr > target) low = mid + 1;
                    else if (curr < target) high = mid - 1;
                    else return 0;
                    currMinQuery = Math.Min(currMinQuery, Math.Abs(curr-target));
                    Console.WriteLine($"L = {L}, low = {low}, mid = {mid}, high = {high}, curr = {curr}");
                }

                int searchQuery = Math.Abs(query(table, L, low) - target);
                searchQuery = Math.Min(searchQuery, currMinQuery);
                Console.WriteLine($"L = {L}, R={low}, searchQuery = {searchQuery}, ans = {ans}");
                ans = Math.Min(ans, searchQuery);
                L++;
            }
            return ans;
        }
    }
}
