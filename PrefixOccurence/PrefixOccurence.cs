// LeetCode 1455
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string sentence = "i love eating burger";
    public static string searchWord = "burg";
    public static string sentence1 = "this problem is an easy problem";
    public static string searchWord1 = "pro";
    public static string sentence2 = "i am tired";
    public static string searchWord2 = "you";
}

namespace Solution
{
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
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.IsPrefixOfWord(Globals.sentence, Globals.searchWord));
            Console.WriteLine(obj.IsPrefixOfWord(Globals.sentence1, Globals.searchWord1));
            Console.WriteLine(obj.IsPrefixOfWord(Globals.sentence2, Globals.searchWord2));
            return;
        }
    }
}