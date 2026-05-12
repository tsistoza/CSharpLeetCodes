// LeetCode 1665
using System;
using System.Collections.Generic;

namespace _1665
{
    public static class Globals
    {
        public static int[][] tasks = { 
            new int[2] { 1, 7 }, 
            new int[2] { 2, 8 }, 
            new int[2] { 3, 9 },
            new int[2] { 4, 10 },
            new int[2] { 5, 11 },
            new int[2] { 6, 12 }
        };
    }
    public class Compare : IComparer<List<int>>
    {
        int IComparer<List<int>>.Compare(List<int>? x, List<int>? y)
        {
            if (x == null || y == null) return 0;
            if (x[1] - x[0] < y[1] - y[0]) return 1;
            if (x[1] - x[0] > y[1] - y[0]) return -1;

            // Equals
            if (x[0] < y[0]) return -1;
            if (x[0] > y[0]) return 1;
            return 0;
        }
    }
    public class Program
    {
        public int MinimumEffort(int[][] tasks)
        {
            Compare cmp = new Compare();
            List<List<int>> tasksToList = new List<List<int>>();
            foreach (int[] task in tasks)
                tasksToList.Add(task.ToList());
            tasksToList.Sort(cmp); // Sort by (minEnergy - actualEnergy), where we sort by descending, if equal then sort by ascending based on actual energy

            int minEnergy = 0, energyLeftover = 0;
            for (int i=0; i<tasksToList.Count; i++)
            {
                if (i == 0)
                {
                    minEnergy += tasksToList[i][1];
                    energyLeftover = minEnergy - tasksToList[i][0];
                    //Console.WriteLine($"MinEnergy = {minEnergy}, where energyLeft = {energyLeftover} and, Tasks = [{tasksToList[i][0]},{tasksToList[i][1]}]");
                    continue;
                }

                if (tasksToList[i][1] <= energyLeftover)
                {
                    energyLeftover -= tasksToList[i][0];
                    //Console.WriteLine($"MinEnergy = {minEnergy}, where energyLeft = {energyLeftover} and, Tasks = [{tasksToList[i][0]},{tasksToList[i][1]}]");
                    continue;
                }

                minEnergy += (tasksToList[i][1] - energyLeftover);
                energyLeftover = tasksToList[i][1] - tasksToList[i][0];
                //Console.WriteLine($"MinEnergy = {minEnergy}, where energyLeft = {energyLeftover} and, Tasks = [{tasksToList[i][0]},{tasksToList[i][1]}]");
            }
            return minEnergy;
        }
    }
}
