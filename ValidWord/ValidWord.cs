// LeetCode 3136
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string word = "a3$e";
}

namespace Solution
{
    public class Program
    {
        public bool IsValid(string word)
        {
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            int vowel = 0;
            int consonant = 0;

            if (word.Length < 3) return false;

            // ASCII ranges that are allowed
            int[,] allowed = { { 48, 57 }, { 65, 90 }, { 97, 122 } }; //[0] = digits, [1] = upper case chars, [2] = lower case chars
         
            for (int i=0; i<word.Length; i++)
            {
                char c = word[i];
                (bool allow, int type) = isAllowed(ref allowed, c); // type = [ 0, 1, 2 ] --> tells the type of char it is
                if (!allow) return false;
                if (type == 0) continue;
                bool isVowel = vowels.Contains(c);
                if (isVowel) vowel++;
                else consonant++;
            }

            return (vowel > 0 && consonant > 0) ? true : false;
        }

        
        private ( bool, int ) isAllowed(ref int[,] allowed, char c)
        {
            for (int i=0; i<allowed.GetLength(0); i++)
            {
                if (c < allowed[i, 0] || c > allowed[i, 1]) continue;
                return ( true, i );
            }
            return (false, -1);
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.IsValid(Globals.word));
            return;
        }
    }
}