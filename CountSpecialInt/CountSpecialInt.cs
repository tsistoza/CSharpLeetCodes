// LeetCode 2376
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 20;
    public static int n1 = 5;
    public static int n2 = 135;
}

namespace Solution
{
    public class Program
    {
        public static int CountSpecialNumbers(int n)
        {
            int count = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 1; i<=n; i++)
            {
                string strInt = i.ToString();
                for (int j = 0; j < strInt.Length; j++)
                {
                    if (map.ContainsKey(strInt[j])) map[strInt[j]]++;
                    else map.Add(strInt[j], 1);
                    if (map[strInt[j]] > 1) break;
                    if (j == strInt.Length - 1) count++;
                }
                map.Clear();
            }
            return count;
        }
        public static void Main()
        {
            Console.WriteLine(CountSpecialNumbers(Globals.n));
            Console.WriteLine(CountSpecialNumbers(Globals.n1));
            Console.WriteLine(CountSpecialNumbers(Globals.n2));
            return;
        }
    }
}