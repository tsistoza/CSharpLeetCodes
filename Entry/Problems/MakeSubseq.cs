// LeetCode 2825
using System;
using System.Collections.Generic;

namespace _2825
{
    public static class Globals
    {
        public static string str1 = "abc";
        public static string str2 = "ad";
    }
    public class Program
    {
        public bool canMakeSubsequence(string str1, string str2)
        {
            int indexStr2 = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                Console.WriteLine($"{str1[i]} : {str2[indexStr2]}");
                if (str1[i]-25 == str2[indexStr2])
                {
                    indexStr2++;
                    continue;
                }
                if (str1[i]+1 == str2[indexStr2])
                {
                    indexStr2++;
                    continue;
                }
                if (str1[i] == str2[indexStr2]) indexStr2++;
            }

            return indexStr2 == str2.Length;
        }
    }
}