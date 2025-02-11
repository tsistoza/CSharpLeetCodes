// LeetCode 1942
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] times = new int[3, 2] { { 1, 4 }, { 2, 3 }, { 4, 6 } };
    public static int targetFriend = 1;
    public static int[,] times1 = new int[3, 2] { { 3, 10 }, { 1, 5 }, { 2, 6 } };
    public static int targetFriend1 = 0;
    public static int[,] times2 = new int[10, 2] { { 1, 2 }, { 2, 10 }, { 3, 10 }, { 4, 10 }, { 5, 10 }, { 6, 10 }, { 7, 10 }, { 8, 10 }, { 9, 10 }, { 10, 11 } };
    public static int targetFriend2 = 8;
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

namespace Solution
{
    
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
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.SmallestChair(Globals.times, Globals.targetFriend));
            Console.WriteLine(obj.SmallestChair(Globals.times1, Globals.targetFriend1));
            Console.WriteLine(obj.SmallestChair(Globals.times2, Globals.targetFriend2));
            return;
        }
    }
}