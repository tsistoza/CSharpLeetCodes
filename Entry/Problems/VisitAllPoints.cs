// LeetCode 1266
using System;
using System.Collections.Generic;

namespace _1266
{
    public static class Globals
    {
        public static int[,] points = { { 3, 2 }, { -2, 2 } };
    }

    public class Program
    {
        public int MinTimeToVisitAllPoints(int[,] points)
        {
            int minSeconds = 0;

            ( int x, int y ) prevPoint = (points[0, 0], points[0, 1]);
            for (int i=1; i<points.GetLength(0); i++)
            {
                ( int x, int y ) dstPoint = (points[i, 0], points[i, 1]);

                // Calculate distance between prevPoint and dstPoint
                int xAbsDir = Math.Abs(dstPoint.x - prevPoint.x); // horizontal distance
                int yAbsDir = Math.Abs(dstPoint.y - prevPoint.y); // vertical distance

                // Prioritize diagonal movement, take min of both directions, add to timer (DIAGONAL MOVEMENT)
                // Subtract min from the larger direction and add that to the timer (STRAIGHT MOVEMENT)
                if (xAbsDir < yAbsDir)
                {
                    minSeconds += xAbsDir;
                    minSeconds += yAbsDir - xAbsDir;
                }
                else if (xAbsDir > yAbsDir)
                {
                    minSeconds += yAbsDir;
                    minSeconds += xAbsDir - yAbsDir;
                }
                else minSeconds += xAbsDir;

                prevPoint = dstPoint;
            }

            return minSeconds;
        }
    }
}
