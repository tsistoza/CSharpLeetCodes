// LeetCode 731
using System;
using System.Collections.Generic;

namespace _731
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
    }
}