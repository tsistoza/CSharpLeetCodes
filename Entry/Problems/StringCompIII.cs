// LeetCode 3163
using System;
using System.Collections.Generic;

namespace _3163
{
    public static class Globals
    {
        public static string testWord = "abcde";
    }
    public class Program
    {
        public static string CompressedString(string word)
        {
            int sum = 1;
            char c = word[0];
            string comp = "";
            for (int i = 1; i<=word.Length; i++)
            {
                if (i >= word.Length)
                {
                    comp += sum.ToString() + c;
                    break;
                }

                if (c == word[i]) sum++;
                else
                {
                    comp += sum.ToString() + c;
                    c = word[i];
                    sum = 1;
                }

                if (sum == 9)
                {
                    comp += sum.ToString() + c;
                    sum = 0;
                }
            }
            return comp;
        }
    }
}
