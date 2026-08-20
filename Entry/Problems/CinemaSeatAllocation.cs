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
            HashSet<(int, int)> reserved = new HashSet<(int, int)>();
            HashSet<int> four1 = new HashSet<int>() { 2, 3, 4, 5 };
            HashSet<int> four2 = new HashSet<int>() { 4, 5, 6, 7 };
            HashSet<int> four3 = new HashSet<int>() { 6, 7, 8, 9 };

            for (int i=0; i<reservedSeats.GetLength(0); i++)
                reserved.Add((reservedSeats[i, 0], reservedSeats[i, 1]));

            bool block1 = true, block2 = true, block3 = true;
            int total = 0;
            for (int i=1; i<=n; i++)
            {
                for (int j=2; j<=9; )
                {
                    if (!reserved.Contains((i, j)))
                    {
                        j++;
                        continue;
                    }

                    if (four1.Contains(j)) block1 = false;
                    if (four2.Contains(j)) block2 = false;
                    if (four3.Contains(j)) block3 = false;

                    if (j == 2 || j == 3) j = 4;
                    else if (j == 4 || j == 5) j = 6;
                    else break;
                }

                if (block1 && block2 && block3) total += 2;
                else if (block1 || block2 || block3) total++;

                block1 = true;
                block2 = true;
                block3 = true;
            }

            return total;
        }
    }
}
