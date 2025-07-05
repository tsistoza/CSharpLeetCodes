// LeetCode 3304
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int k = 10;
}

namespace Solution
{
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

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.KthCharacter(Globals.k));
            return;
        }
    }
}