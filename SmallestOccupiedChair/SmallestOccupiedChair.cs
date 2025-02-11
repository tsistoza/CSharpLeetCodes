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

namespace Solution
{
    public class Program
    {
        public int SmallestChair(int[,] times, int targetFriend)
        {
            Dictionary<int,int> line = new Dictionary<int,int>();
            for (int i=0; i<times.GetLength(0); i++)
            {
                for (int j = times[i,0]; j < times[i,1]; j++)
                {
                    if (line.ContainsKey(j)) line[j]++;
                    else line.Add(j, 1);
                }
            }
            return line[times[targetFriend,0]]-1;
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