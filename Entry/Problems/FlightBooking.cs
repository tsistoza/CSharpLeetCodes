// LeetCode 1109
using System;
using System.Collections.Generic;

namespace _1109
{
    public static class Globals
    {
        public static int[][] booking = new int[3][]
        {
            new int[3] { 1, 2, 10 },
            new int[3] { 2, 3, 20 },
            new int[3] { 2, 5, 25 }
        };
        public static int n = 5;

        public static int[][] booking1 = new int[2][]
        {
            new int[3] { 1, 2, 10 },
            new int[3] { 2, 2, 15 }
        };
        public static int n1 = 2;
    }
    public class Program
    {
        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            Dictionary<int,int> line = new Dictionary<int,int>();
            for (int i=0; i<bookings.GetLength(0); i++)
            {
                for (int j=bookings[i][0]; j<=bookings[i][1]; j++)
                {
                    if (line.ContainsKey(j)) line[j] += bookings[i][2];
                    else line.Add(j, bookings[i][2]);
                }
            }

            List<int> totals = new List<int>(line.Values);
            return totals.ToArray();
        }
    }
}