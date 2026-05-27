// LeetCode 3121
using System;
using System.Collections.Generic;

namespace _3121
{
    public static class Globals
    {
        public static string word = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
    public class Program
    {
        public (char, char) LowerAndUpper(char c)
        {
            if (c < 'a') return ((char)((int)c + 32), c);
            return (c, (char)((int)c - 32));
        }
        public int NumberOfSpecialChars(string word)
        {
            int ans = 0;
            Dictionary<int, int[]> count = new Dictionary<int, int[]>();

            for(int i=0; i<word.Length; i++)
            {
                (char lower, char upper) = LowerAndUpper(word[i]);
                if (!count.ContainsKey(lower))
                {
                    if (word[i] == lower) count.Add(lower, new int[2] { -1, -1 });
                    else count.Add(lower, new int[2] { i, -1 });
                    continue;
                }


                if (count[lower][1] == 1) continue;

                if (word[i] == lower)
                {
                    if (count[lower][0] == -1) continue;
                    if (count[lower][1] == 0) ans--;
                    count[lower][1] = 1;
                    continue;
                }

                if (word[i] == upper && count[lower][0] == -1)
                {
                    ans++;
                    count[lower][0] = i;
                    count[lower][1] = 0;
                }

            }
            return ans;
        }
    }
}
