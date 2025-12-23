// LeetCode 1128
using System;
using System.Collections.Generic;

namespace _1128
{
    public static class Globals
    {
        public static List<List<int>> dominoes = new List<List<int>>()
        {
            new List<int>() { 1, 2 },
            new List<int>() { 1, 2 },
            new List<int>() { 1, 1 },
            new List<int>() { 1, 2 },
            new List<int>() { 2, 2 }
        };
    }
    public class Program
    {
        public int NumEquivDominoPairs(List<List<int>> dominoes)
        {
            int count = 0;
            Dictionary<Tuple<int, int>, int> dict = new Dictionary<Tuple<int, int>, int>();
            foreach (List<int> domino in dominoes)
            {
                Tuple<int, int> curr = new Tuple<int, int>(domino[0], domino[1]);
                Tuple<int, int> revCurr = new Tuple<int, int>(domino[1], domino[0]);

                if (!dict.TryAdd(curr,1))
                    dict[curr]++;

                if (!dict.TryAdd(revCurr, 1) && domino[0] != domino[1])
                    dict[revCurr]++;

                count += dict[curr] - 1;
            }
            return count;
        }
    }
}