// LeetCode 1072
using System;
using System.Collections.Generic;

namespace _1072
{
    public static class Globals
    {
        public static List<List<int>> matrix = new List<List<int>>()
        {
            new List<int>() { 0, 1 },
            new List<int>() { 1, 1 }
        };
    }
    public class Program
    {
        public int MaxEqualRowsAfterFlips(List<List<int>> matrix)
        {
            // Map will be used to find patterns
            Dictionary<string, int> map = new Dictionary<string, int>();

            // Key is to find a pattern in the data
            // The pattern will be a string s, in which the first number of a row will be 'a'
            // Ex: row = 1100, s = aabb / row = 0011, s=aabb /
            foreach (List<int> row in matrix)
            {
                Tuple<int, char> kvp = new Tuple<int, char>(row[0], 'a');
                string s = "";
                for (int i = 0; i<row.Count; i++)
                {
                    if (kvp.Item1 == row[i])
                        s += kvp.Item2;
                    else s += 'b';
                }
                Console.WriteLine(s);
                if (map.ContainsKey(s)) map[s]++; // If such a pattern exists, then increment the counter
                else map[s] = 1;
                s = string.Empty;
            }

            List<int> val = new List<int>(map.Values);
            val.Sort();
            return val[val.Count-1]; // return the pattern that occurs the most
        }
    }
}