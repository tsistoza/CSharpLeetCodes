// LeetCode 1910
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string s = "daabcbaabcbc";
    public static string part = "abc";
    public static string s1 = "axxxxyyyyb";
    public static string part1 = "xy";
}

namespace Solution
{
    public class Program
    {
        private (bool, string) remove(string s, string part)
        {
            for (int i=0; i<s.Length; i++)
            {
                if (s[i] != part[0]) continue;
                if (i + part.Length - 1 >= s.Length) continue;

                if (s.Substring(i, part.Length) == part)
                {
                    string newStr = s.Remove(i, part.Length);
                    return (true, newStr);
                }
            }

            return (false, s);
        }
        public string RemoveOccurences(string s, string part)
        {
            (bool flag, string newStr) = remove(s, part);
            while (flag)
                (flag, newStr) = remove(newStr, part);
            return newStr;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.RemoveOccurences(Globals.s, Globals.part));
            Console.WriteLine(obj.RemoveOccurences(Globals.s1, Globals.part1));
            return;
        }
    }
}