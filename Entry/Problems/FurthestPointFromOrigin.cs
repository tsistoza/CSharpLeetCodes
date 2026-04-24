using System;
using System.Collections.Generic;

namespace _2833
{
    public static class Globals
    {
        public static string moves = "_______";
    }
    public class Program
    {
        public int FurthestDistanceFromOrigin(string moves)
        {
            int numL = 0, numR = 0, numUnder = 0;
            foreach (char c in moves)
            {
                if (c == 'L') numL++;
                else if (c == 'R') numR++;
                else numUnder++;
            }

            int dist = Math.Abs(numL - numR) + numUnder;
            return dist;
        }
    }
}
