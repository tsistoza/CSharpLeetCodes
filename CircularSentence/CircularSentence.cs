// LeetCode 2490
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string sentence = "leetcode exercises sound delightful";
    public static string sentence1 = "eetcode";
    public static string sentence2 = "Leetcode is cool";
}

namespace Solution
{
    public class Program
    {
        public bool IsCircularSentence(string sentence)
        {
            if (sentence[0] != sentence[sentence.Length - 1]) return false;

            
            for (int i=0; i<sentence.Length; i++)
            {
                if (sentence[i] != ' ') continue;
                char last = sentence[i - 1];
                char first = sentence[i + 1];
                if (last != first) return false;
            }

            return true;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.IsCircularSentence(Globals.sentence));
            Console.WriteLine(obj.IsCircularSentence(Globals.sentence1));
            Console.WriteLine(obj.IsCircularSentence(Globals.sentence2));
            return;
        }
    }
}