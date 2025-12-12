// LeetCode 3531
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 5;
    public static int[,] buildings = { {1, 3}, {3, 2}, {3, 3}, {3, 5}, {5, 3} };
}

namespace Solution
{
    public class Program
    {
        public int CountCoveredBuildings(int n, int[,] buildings)
        {
            int minVert = int.MaxValue;
            int maxVert = int.MinValue;
            int minHoriz = minVert;
            int maxHoriz = maxVert;

            int numBuildings = 0;
            for (int i=0; i<buildings.GetLength(0); i++)
            {
                minVert = Math.Min(minVert, buildings[i, 0]);
                maxVert = Math.Max(maxVert, buildings[i, 0]);
                minHoriz = Math.Min(minHoriz, buildings[i, 1]);
                maxHoriz = Math.Max(maxHoriz, buildings[i, 1]);
            }

            for (int i = 0; i < buildings.GetLength(0); i++)
            {
                int x = buildings[i, 0], y = buildings[i, 1];
                if (x == minVert || x == maxVert) continue;
                if (y == minHoriz || y == maxHoriz) continue;
                numBuildings++;
            }
            return numBuildings;
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CountCoveredBuildings(Globals.n, Globals.buildings));
            return;
        }
    }
}