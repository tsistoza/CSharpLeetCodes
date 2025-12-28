// LeetCode 3335
using System;
using System.Collections.Generic;

namespace _3335
{
    public static class Globals
    {
        public static string s = "abcyy";
        public static int t = 2;
    }
    public class Program
    {
        public int LengthAfterTransformation(string s, int t)
        {
            int mod = 1000000007;
            int[] map = new int[26];
            for (int i=0; i<s.Length; i++)
                map[s[i] - 97]++;

            for (int i=0; i < t; i++)
            {
                int[] newMap = new int[26];
                Array.Copy(map, newMap, map.Length);
                newMap[0] = map[25];
                newMap[1] = (map[25] + map[0]) % mod;
                for (int index = 2; index < 26; index++) newMap[index] = map[index - 1];
                map = newMap;
            }

            return Enumerable.Sum(map) % mod;
        }
    }
}
