// LeetCode 1854
using System;
using System.Collections.Generic;

// Will be using the Line Sweep Algorithm

namespace _1854
{
    public static class Globals
    {
        public static readonly List<List<int>> logs = new List<List<int>>()
        {
            new List<int> { 1993, 1999 },
            new List<int> { 2000, 2010 }
        };
    }
    public class Program
    {
        public class Compare : IComparer<Tuple<int, int>>
        {
            int IComparer<Tuple<int, int>>.Compare(Tuple<int, int>? x, Tuple<int, int>? y)
            {
                if (x!.Item2 > y!.Item2) return -1;
                if (x.Item2 < y.Item2) return 1;
                if (x.Item2 == y.Item2 && x.Item1 < y.Item1) return -1;
                if (x.Item2 == y.Item2 && y.Item1 > x.Item1) return 1;
                return 0;
            }
        }

        public int MaximumPopulation(List<List<int>> logs)
        {
            // Storing the population has a key, value pair, where key is the year, and value the population
            Dictionary<int, int> populationByYear = new Dictionary<int, int>(); // This is the Line
            
            // Populate the dictionary
            foreach(List<int> log in logs)
            {
                for (int i = log[0]; i < log[1]; i++)
                {
                    if (populationByYear.ContainsKey(i)) populationByYear[i]++;
                    else populationByYear[i] = 1;
                }   
            }

            List<Tuple<int, int>> population = new List<Tuple<int, int>>();
            foreach (List<int> log in logs)
            {
                population.Add(new Tuple<int, int>(log[0], populationByYear[log[0]]));
                Console.WriteLine($"Year={log[0]}, Population={populationByYear[log[0]]}");
            }
            Compare cmp = new Compare();
            population.Sort(cmp);
            return population[0].Item1;
        }
    }
}