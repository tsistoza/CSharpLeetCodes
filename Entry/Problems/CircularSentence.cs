// LeetCode 2490
using System;
using System.Collections.Generic;

namespace _2490
{
    public static class Globals
    {
        public static string sentence = "leetcode exercises sound delightful";
    }
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
        
    }
}