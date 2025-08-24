// LeetCode 119
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int rowIndex = 3;
}

namespace Solution
{
    public class Program
    {
        private static void PrettyPrint(List<int> list)
        {
            Console.Write("{ ");
            foreach (int i in list) Console.Write($"{i} ");
            Console.WriteLine("}");
            return;
        }
        public List<int> GetRow(int rowIndex)
        {
            List<int> pastRow = new List<int>() { 1, 1 };
            if (rowIndex == 0) return new List<int>() { 1 };
            if (rowIndex == 1) return pastRow;

            for (int i=2; i<rowIndex+1; i++)
            {
                List<int> currRow = new List<int>() { 1 };
                bool zig = false;
                for (int j=0, k=1; j<pastRow.Count && k<pastRow.Count; )
                {
                    currRow.Add(pastRow[j] + pastRow[k]);
                    if (zig) k += 2;
                    else j += 2;
                    zig = !zig;
                }
                currRow.Add(1);
                pastRow = currRow;
            }

            return pastRow;
        }
        public static void Main()
        {
            Program obj = new Program();
            Program.PrettyPrint(obj.GetRow(Globals.rowIndex));
            return;
        }
    }
}