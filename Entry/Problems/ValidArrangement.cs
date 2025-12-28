// LeetCode 2097
using System;
using System.Collections.Generic;

namespace _2097
{
    public static class Globals
    {
        public static int[,] pairs = new int[4, 2] { { 5, 1 }, { 4, 5 }, { 11, 9 }, { 9, 4 } };
        public static int[,] pairs1 = new int[3, 2] { { 1, 3 }, { 3, 2 }, { 2, 1 } };
    }
    public class Program
    {
        public IEnumerable<Tuple<int,int>> ValidArrangement(int[,] pairs)
        {
            List<Tuple<int,int>> result = new List<Tuple<int,int>>();
            Dictionary<int, int> CheckEnd = new Dictionary<int, int>();
            Dictionary<int, int> CheckStart = new Dictionary<int, int>();
            for (int i = 0; i < pairs.GetLength(0); i++)
            {
                CheckEnd.Add(pairs[i, 1], pairs[i, 0]);
                CheckStart.Add(pairs[i, 0], pairs[i, 1]);
            }
            
            for (int i=0; i<pairs.GetLength(0); i++)
            {
                int end = pairs[i, 1];
                while (CheckEnd.ContainsKey(end))
                {
                    result.Add(new Tuple<int, int>(CheckEnd[end], end));
                    if (!CheckStart.ContainsKey(end)) break; 
                    end = CheckStart[end];
                    if (result.Count == pairs.GetLength(0)) break;
                }
                if (result.Count == pairs.GetLength(0)) break;
                result.Clear();
            }
            return result;
        }
    }
}
