// LeetCode 1415
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int n = 1;
    public static int k = 3;
    public static int n1 = 1;
    public static int k1 = 4;
    public static int n2 = 3;
    public static int k2 = 9;
}

namespace Solution
{
    public class Program
    {
        public class Compare : IComparer<string>
        {
            int IComparer<string>.Compare(string? x, string? y)
            {
                if (x!.Length < y!.Length) return -1;
                if (x.Length > y.Length) return 1;
                if (x.Length == y.Length)
                {
                    int index = 0;
                    while(x[index] == y[index]) index++;
                    if (index >= x.Length) return 0;
                    if (x[index] < y[index]) return -1;
                    if (x[index] > y[index]) return 1;
                }
                return 0;
            }
        }
        private static void generateHappyString(int n, string curr, List<string> happyStrings)
        {
            if (curr.Count() == n && !happyStrings.Contains(curr)) happyStrings.Add(curr);
            if (curr.Count() >= n) return;

            
            for (char ch = 'a'; ch != 'd'; ch++)
            {
                string temp = curr;
                if (curr[curr.Count() - 1] == ch) continue;
                temp += ch;
                generateHappyString(n, temp, happyStrings);
            }
            return;
        }
        public static string GetHappyString(int n, int k)
        {
            List<string> happyStrings = new List<string>();
            for (char ch='a'; ch!='d'; ch++)
                generateHappyString(n, new String(ch, 1), happyStrings);

            Compare cmp = new Compare();
            happyStrings.Sort(cmp);
            if (k > happyStrings.Count) return "";
            return happyStrings[k-1];
        }
        public static void Main()
        {
            Console.WriteLine(GetHappyString(Globals.n, Globals.k));
            Console.WriteLine(GetHappyString(Globals.n1, Globals.k1));
            Console.WriteLine(GetHappyString(Globals.n2, Globals.k2));
            return;
        }
    }
}