// LeetCoe 2064
using System;
using System.Collections.Generic;

public static class Globals
{
    public static readonly int n = 6;
    public static readonly List<int> quantities = new List<int>() { 11, 6 };
    public static readonly int n1 = 7;
    public static readonly List<int> quantities1 = new List<int>() { 15, 10, 10 };
    public static readonly int n2 = 1;
    public static readonly List<int> quantities2 = new List<int>() { 10000 };
}

namespace Solution
{
    public class Program
    {
        public int minimizedMaximum(int n, List<int> quantities)
        {
            // We want to minimize the maximize, to do that we want an equal distribution of products across the stores.
            // Since a store can only have at most 1 product, we can just add all the quantities together, and distribute them equally, and then add the remainder
            
            int distribution = 0;
            foreach (int quantity in quantities) distribution += quantity; // Add quantities together
            int remainder = distribution % n;
            distribution = (distribution - remainder) / n; // Find equal distribution between stores

            List<int> distributions = new List<int>();
            for (int i = 0; i < n; i++)
            {
                distributions.Add(distribution);
                if (remainder > 0)
                {
                    distributions[i]++; // Add the remainder
                    remainder--;
                }
            }

            distributions.Sort();
            return distributions[distributions.Count-1];
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine(obj.minimizedMaximum(Globals.n, Globals.quantities));
            Console.WriteLine(obj.minimizedMaximum(Globals.n1, Globals.quantities1));
            Console.WriteLine(obj.minimizedMaximum(Globals.n2, Globals.quantities2));
            return;
        }
    }
}