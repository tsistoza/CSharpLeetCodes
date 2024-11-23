// LeetCode 731
using System;
using System.Collections.Generic;

namespace Solution
{
    public class Program
    {
        public SortedList<int, int> line;

        public bool Book(int startTime, int endTime)
        {
            SortedList<int, int> tempLine = this.line;
            for (int i = startTime; i < endTime; i++)
            {
                if (tempLine.ContainsKey(i))
                {
                    tempLine[i]++;
                    if (tempLine[i] > 2) return false;
                }
                else tempLine.Add(i, 1); 
            }
            this.line = tempLine;
            return true;
        }

        public Program()
        {
            line = new SortedList<int, int>();
        }


        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.Book(10, 20));
            Console.WriteLine(obj.Book(50, 60));
            Console.WriteLine(obj.Book(10, 40));
            Console.WriteLine(obj.Book(5, 15));
            Console.WriteLine(obj.Book(5, 10));
            Console.WriteLine(obj.Book(25, 55));
            return;
        }
    }
}