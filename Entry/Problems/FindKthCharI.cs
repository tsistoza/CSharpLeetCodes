// LeetCode 3304
using System;
using System.Collections.Generic;

namespace _3304
{
    public static class Globals
    {
        public static int k = 10;
    }

    public class Program
    {
        public char KthCharacter(int k)
        {
            string word = "a";
            while (word.Length < k)
            {
                string append = "";
                foreach (char c in word) append += (c + 1 > 'z') ? 'a' : (char) (c + 1);
                word += append;
            }
            Console.WriteLine(word);
            return word[k];
        }
    }
}