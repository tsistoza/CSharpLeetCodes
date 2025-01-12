// LeetCode 2116
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string s = "))()))";
    public static string locked = "010100";
    public static string s1 = "()()";
    public static string locked1 = "0000";
    public static string s2 = ")";
    public static string locked2 = "0";
}

namespace Solution
{
    public class Program
    {
        public bool canBeValid(string s, string locked)
        {
            if (s.Length % 2 == 1) return false;
            for (int i=0; i<s.Length; i++)
            {
                if (i % 2 == 0 && s[i] != '(' && locked[i] == 1)
                    return false;
                if (i % 2 == 1 && s[i] != ')' && locked[i] == 1)
                    return false;
            }
            return true;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.canBeValid(Globals.s, Globals.locked));
            Console.WriteLine(obj.canBeValid(Globals.s1, Globals.locked1));
            Console.WriteLine(obj.canBeValid(Globals.s2, Globals.locked2));
            return;
        }
    }
}