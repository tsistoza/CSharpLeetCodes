﻿// LeetCode 2054
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] events = { { 1, 3, 2 }, { 4, 5, 2 }, { 2, 4, 3 } };
    public static int[,] events1 = { { 1, 3, 2 }, { 4, 5, 2 }, { 1, 5, 5 } };
    public static int[,] events2 = { { 1, 5, 3 }, { 1, 5, 1 }, { 6, 6, 5 } };
};

namespace Solution
{
    public class Program
    {
        
        public int MaxTwoEvents(int[,] events)
        {
            Dictionary<int, int> line = new Dictionary<int, int>(); // Use a line sweep algorithm to check if there overlapping
            
            int maxVal = int.MinValue;
            for (int i = 0; i<events.GetLength(0); i++) // One Event
            {
                maxVal = (maxVal < events[i, 2]) ? events[i, 2] : maxVal;
                for (int j = events[i,0]; j<=events[i,1]; j++) line.Add(j, 1);
                for (int j = i+1; j<events.GetLength(0); j++) // Second Event
                {
                    for (int k = events[j, 0]; k <= events[j, 1]; k++)
                    {
                        if (line.ContainsKey(k)) break; // If Overlapping Break
                        if (k == events[j, 1] && maxVal < (events[i, 2] + events[j, 2])) maxVal = events[i, 2] + events[j, 2];
                    }
                }
                line.Clear();
            }

            return maxVal;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxTwoEvents(Globals.events));
            Console.WriteLine(obj.MaxTwoEvents(Globals.events1));
            Console.WriteLine(obj.MaxTwoEvents(Globals.events2));
            return;
        }
    }
}