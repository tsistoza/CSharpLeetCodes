// LeetCode 2116
using System;
using System.Collections.Generic;

namespace _2116
{
    public static class Globals
    {
        public static string s = "))()))";
        public static string locked = "010100";
    }
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
    }
}