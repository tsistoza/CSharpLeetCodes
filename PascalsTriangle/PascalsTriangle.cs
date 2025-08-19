// LeetCode 118
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int numRows = 5;
}

namespace Solution
{
    public class Program
    {
        private static void ReadList(List<List<int>> result)
        {
            Console.Write("{ ");
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write("{");
                for (int j = 0; j < result[i].Count; j++)
                {
                    Console.Write($" {result[i][j]} ");
                }
                Console.Write("}, ");
            }
            Console.WriteLine(" }");
            return;
        }
        public List<List<int>> Generate(int numRows)
        {
            List<List<int>> result = new List<List<int>>() { new List<int>() { 1 } };
            if (numRows == 1) return result;
            result.Add(new List<int> { 1, 1 });

            while (result.Count < numRows)
            {
                List<int> newList = new List<int>() { 1 };
                bool jump = false;
                for (int i=0,j=1; i < result[result.Count - 1].Count && j < result[result.Count - 1].Count;)
                {
                    newList.Add(result[result.Count - 1][i] + result[result.Count - 1][j]);
                    if (!jump) i += 2;
                    if (jump) j += 2;
                    jump = !jump;
                }
                newList.Add(1);
                result.Add(newList);
            }
            return result;
        }
        public static void Main()
        {
            Program obj = new Program();
            Program.ReadList(obj.Generate(Globals.numRows));
            return;
        }
    }
}