// LeetCode 1942
using System;
using System.Collections.Generic;

namespace _1942
{
    public static class Globals
    {
        public static int[,] times = new int[3, 2] { { 1, 4 }, { 2, 3 }, { 4, 6 } };
        public static int targetFriend = 1;
    }

    public class Triplet
    {
        public int index;
        public int start;
        public int end;

        public Triplet(int _index, int _start, int _end)
        {
            index = _index; start = _start; end = _end;
        }
    }

    public class Compare : IComparer<Triplet>
    {
        int IComparer<Triplet>.Compare(Triplet? x, Triplet? y)
        {
            if (x!.start < y!.start) return -1;
            if (x.start > y.start) return 1;
            return 0;
        }
    }
    
    public class Program
    {
        public int SmallestChair(int[,] times, int targetFriend)
        {
            List<Triplet> newTimes = new List<Triplet>();
            for (int i=0; i<times.GetLength(0); i++)
                newTimes.Add(new Triplet(i, times[i, 0], times[i, 1]));
            Compare cmp = new Compare();
            newTimes.Sort(cmp);

            Dictionary<int,int> line = new Dictionary<int,int>();
            for (int i=0; i<newTimes.Count; i++)
            {
                for (int j = newTimes[i].start; j < newTimes[i].end; j++)
                {
                    if (line.ContainsKey(j)) line[j]++;
                    else line.Add(j, 1);
                }
                if (newTimes[i].index == targetFriend) return line[newTimes[i].start] - 1;
            }

            return -1;
        }
    }
}
