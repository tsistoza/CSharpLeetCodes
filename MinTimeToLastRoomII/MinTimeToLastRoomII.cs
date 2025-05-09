// LeetCode 3342
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[,] moveTime = { { 0, 1 }, { 1, 2 } };
}

namespace Solution
{
    public class Program
    {
        public int MinTimeToReach(int[,] moveTime)
        {
            int time = int.MaxValue;
            PriorityQueue<Tuple<int, int, int, int>, int> queue = new PriorityQueue<Tuple<int, int, int, int>, int>();
            queue.Enqueue(new Tuple<int,int,int,int>(0, 0, 0, 1), 0);
            while (queue.Count > 0)
            {
                Tuple<int, int, int, int> curr = queue.Dequeue();

                if (curr.Item2 == moveTime.GetLength(0)-1 && curr.Item3 == moveTime.GetLength(1)-1)
                {
                    time = curr.Item1;
                    break;
                }

                List<int> dirX = new List<int>() { -1, 0, 1, 0 };
                List<int> dirY = new List<int>() { 0, -1, 0, 1 };
                for (int i=0; i<4; i++)
                {
                    int newX = curr.Item2 + dirX[i];
                    int newY = curr.Item3 + dirY[i];
                    int newTime = curr.Item1;
                    int newTight = (curr.Item4 == 1) ? 2 : 1;

                    if (newX < 0 || newY < 0 || newX >= moveTime.GetLength(0) || newY >= moveTime.GetLength(1)) continue;

                    if (newTime < moveTime[newX, newY])
                        newTime = moveTime[newX, newY];

                    newTime += (curr.Item4 == 1) ? 1 : 2;

                    Tuple<int, int, int, int> newQItem = new Tuple<int, int, int, int>(newTime, newX, newY, newTight);
                    queue.Enqueue(newQItem, newTime);
                }
            }

            return time;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MinTimeToReach(Globals.moveTime));
            return;
        }
    }
}