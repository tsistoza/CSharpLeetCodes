// LeetCode 1455
using System;
using System.Collections.Generic;

namespace _1455
{
    public static class Globals
    {
        public static string sentence = "i love eating burger";
        public static string searchWord = "burg";
    }
    public class Program
    {
        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            int word = 1;

            int i = 0;
            for (; i<sentence.Length; i++)
            {
                if (sentence[i] == ' ') word++; 
                if (sentence[i] != searchWord[0]) continue;
                
                string sub = sentence.Substring(i, searchWord.Length);
                if (sub == searchWord) return word;
            }
            return -1;
        }
    }
}