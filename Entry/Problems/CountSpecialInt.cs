// LeetCode 2376
using System;
using System.Collections.Generic;

namespace _2376
{
    public static class Globals
    {
        public static int n = 20;
    }
    public class Program
    {
        public int CountSpecialNumbers(int n)
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
    }
}