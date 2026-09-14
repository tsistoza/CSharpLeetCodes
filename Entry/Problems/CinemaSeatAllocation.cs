// LeetCode 1386
using System;
using System.Collections.Generic;

namespace _1386
{
    public static class Globals
    {
        public static int n = 4;
        public static int[,] reservedSeats =
        {
            { 4, 3 }, { 1, 4 }, { 4, 6 }, { 1, 7 }
        };
    }
    public class Program
    {
        public int MaxNumberOfFamilies(int n, int[,] reservedSeats)
        {
            HashSet<int> four1 = new HashSet<int>() { 2, 3, 4, 5 };
            HashSet<int> four2 = new HashSet<int>() { 4, 5, 6, 7 };
            HashSet<int> four3 = new HashSet<int>() { 6, 7, 8, 9 };
            Dictionary<int, int> allocatedSeats = new Dictionary<int, int>();
            int total = n * 2;

            int blocks = 0b111;
            for (int i=0; i<reservedSeats.GetLength(0); i++)
            {
                int row = reservedSeats[i, 0], col = reservedSeats[i, 1];
                if (!allocatedSeats.ContainsKey(row))
                    allocatedSeats.Add(row, blocks);

                if (col < 2 || col > 9) continue;
                
                if (four1.Contains(col)) blocks &= 0b011;
                if (four2.Contains(col)) blocks &= 0b101;
                if (four3.Contains(col)) blocks &= 0b110;

                int currSeating = allocatedSeats[row];
                allocatedSeats[row] &= blocks;
                if (currSeating == 7 && currSeating > allocatedSeats[row]) total--;
                if (allocatedSeats[row] == 0 && currSeating > 0) total--;
                
                blocks = 0b111;
            }
            return total;
        }
    }
}
