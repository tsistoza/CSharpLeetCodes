// LeetCode 2071
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<int> tasks = new List<int>() { 3, 2, 1 };
    public static List<int> workers = new List<int>() { 0, 3, 3 };
    public static int pills = 1;
    public static int strength = 1;
}

namespace Solution
{
    public class Compare : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            if (x < y) return 1;
            if (x > y) return -1;
            return 0;
        }
    }
    public class Program
    {
        public int MaxTaskAssign(List<int> tasks, List<int> workers, int pills, int strength)
        {
            int count = 0;
            Compare cmp = new Compare();
            tasks.Sort();
            workers.Sort(cmp);

            Stack<int> taskQ = new Stack<int>();
            foreach (int task in tasks) taskQ.Push(task);

            while (taskQ.Count > 0 && workers.Count > 0)
            {
                int currTask = taskQ.Pop();

                if (workers[0] >= currTask) // Since this worker is able to handle currTask use this worker
                {
                    workers.RemoveAt(0);
                    count++;
                    continue;
                }

                // else since currTask > maxWorker, find a worker that can be pilled just enough to get currTask done
                int low = 0;
                for (int high = workers.Count - 1; low < high && pills > 0; )
                {
                    int mid = low + (high - low) / 2;
                    // Pill check
                    if (workers[mid]+strength < currTask)
                        high = mid - 1;
                    if (workers[mid]+strength > currTask)
                        low = mid + 1;
                    if (workers[mid]+strength == currTask)
                    {
                        low = mid;
                        break;
                    }
                    if (low == high)
                    {
                        low = (workers[low] < strength) ? low - 1 : high;
                        break;
                    }       
                }

                if (workers[low]+strength >= currTask && pills > 0)
                {
                    workers.RemoveAt(low);
                    count++;
                    pills--;
                }
            }
            return count;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxTaskAssign(Globals.tasks, Globals.workers, Globals.pills, Globals.strength));
            return;
        }
    }
}