// LeetCode 2381
using System;
using System.Collections.Generic;

namespace _2381
{
    public static class Globals
    {
        public static string s = "abc";
        public static int[][] shifts = new int[3][]
        {
            new int[3] { 0, 1, 0 },
            new int[3] { 1, 2, 1 },
            new int[3] { 0, 2, 1 }
        };

        public static string s1 = "dztz";
        public static int[][] shifts1 = new int[2][]
        {
            new int[3] { 0, 0, 0 },
            new int[3] { 1, 1, 1 }
        };
    }
    public class Program
    {
        public string ShiftingLetters(string s, int[][] shifts)
        {
            string ans = "";
            List<char> stringify = new List<char>(s.ToList());
            for (int i=0; i<shifts.GetLength(0); i++)
            {
                for (int start = shifts[i][0]; start <= shifts[i][1]; start++)
                {
                    if (shifts[i][2] == 0)
                    {
                        if (stringify[start] == 'a') stringify[start] = 'z';
                        else stringify[start]--;
                        continue;
                    }
                    if (shifts[i][2] == 1)
                    {
                        if (stringify[start] == 'z') stringify[start] = 'a';
                        else stringify[start]++;
                    }
                }
            }
            
            foreach (char c in stringify) ans += c;
            return ans;
        }
    }
}