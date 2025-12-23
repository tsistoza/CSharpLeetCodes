// LeetCode 3170
using System;
using System.Collections.Generic;

namespace _3170
{
    public static class Globals
    {
        public static string s = "abc*de*fgh*";
    }
    public class Compare : IComparer<(char, int)>
    {
        int IComparer<(char,int)>.Compare((char,int) x, (char, int) y)
        {
            if (x.Item1 < y.Item1) return -1;
            if (x.Item1 > y.Item1) return 1;

            if (x.Item2 < y.Item2) return 1;
            if (x.Item2 > y.Item2) return -1;

            return 0;
        }
    }
    public class Program
    {
        public string ClearStars(string s)
        {
            String newStr = "";
            char[] arr = s.ToCharArray();
            Compare cmp = new Compare();
            PriorityQueue<char,(char,int)> queue = new PriorityQueue<char,(char, int)>(cmp);
            for (int i=0; i<s.Length; i++)
            {
                if (s[i] == '*')
                {
                    char elem;
                    (char, int) prior;
                    if (!queue.TryDequeue(out elem, out prior)) continue;
                    arr[prior.Item2] = ' ';
                }
                else
                    queue.Enqueue(s[i], (s[i], i));
            }

            foreach(char c in arr)
            {
                if (c == '*' || c == ' ') continue;
                newStr += c;
            }

            return newStr;
        }
    }
}