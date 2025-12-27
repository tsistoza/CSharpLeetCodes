// LeetCode 1910
using System;
using System.Collections.Generic;

namespace _1910
{
    public static class Globals
    {
        public static string s = "daabcbaabcbc";
        public static string part = "abc";
    }
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
    }
}
