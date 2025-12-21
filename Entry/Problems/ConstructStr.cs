// LeetCode 2182
using System;
using System.Collections.Generic;

namespace _2182
{
    public static class Globals
    {
        public static int repeatLimit = 3;
        public static string s = "cczazcc";
    }
    public class Program
    {
        public class Compare : IComparer<char>
        {
            int IComparer<char>.Compare(char x, char y)
            {
                if (x < y) return 1;
                if (x > y) return -1;
                return 0;
            }
        }

        public string RepeatLimitedString(string s, int repeatLimit)
        {
            Compare cmp = new Compare();
            SortedDictionary<char, int> kvp = new SortedDictionary<char, int>(cmp);
            string construct = "";
            foreach (char c in s)
            {
                if (kvp.ContainsKey(c)) kvp[c]++;
                else kvp.Add(c, 1);
            }

            // Construct valid string s
            List<char> list = new List<char>(kvp.Keys);
            int repeat = 0;
            for (int i=0; i<list.Count; i++)
            {
                repeat = 0;
                while (kvp[list[i]] > 0)
                {
                    if (repeat == repeatLimit) // if exceed repeat Limit get the next char, then continue
                    {
                        if (i + 1 > list.Count - 1) break;
                        kvp[list[i + 1]]--;
                        construct += list[i + 1];
                        repeat = 0;
                        continue;
                    }
                    kvp[list[i]]--;
                    construct += list[i];
                    repeat++;
                }
                if (kvp[list[i]] == 0) kvp.Remove(list[i]);
            }
            return construct;
        }
    }
}