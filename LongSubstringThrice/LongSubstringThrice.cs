﻿// LeetCode 2981
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string s = "aaaa";
    public static string s1 = "abcdef";
    public static string s2 = "abcaba";
}

namespace Solution
{
    public class Program
    {

        public int MaximumLength(string s)
        {
            Dictionary<string, int> dict = new Dictionary<string,int>();
            int maxLength = int.MinValue;
            for (int i=0; i<s.Length; i++) // anchor
            {
                string substring = $"{s[i]}";
                for (int j=i+1; j<=s.Length; j++) // window
                {
                    if (dict.ContainsKey(substring))
                    {
                        dict[substring]++;
                        if (dict[substring] == 3) maxLength = substring.Length;
                    }
                    else dict.Add(substring, 1);
                    if (j == s.Length) break;
                    if (substring[0] != s[j]) break;
                    substring += s[j];
                }
            }
            if (maxLength == int.MinValue) return -1;
            return maxLength;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaximumLength(Globals.s));
            Console.WriteLine(obj.MaximumLength(Globals.s1));
            Console.WriteLine(obj.MaximumLength(Globals.s2));
            return;
        }
    }
}