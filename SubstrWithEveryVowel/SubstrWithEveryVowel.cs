// LeetCode 3305
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string word = "ieaouqqieaouqq";
    public static int k = 1;
}

namespace Solution
{
    public class Program
    {
        public int countOfSubstrings(string word, int k)
        {
            int numStrings = 0;
            Dictionary<char, int> dict;
            for (int i = 0; i < word.Length; i++)
            {
                if (word.Length - i + 1 < 5) break;
                int consonants = 0;
                dict = new Dictionary<char, int>() { { 'a', 0 }, { 'e', 0 }, { 'i', 0 }, { 'o', 0 }, { 'u', 0 } };
                for (int windowSize = 1; windowSize + i - 1 < word.Length; windowSize++)
                {
                    if (consonants > k) break;

                    if (!dict.ContainsKey(word[i + windowSize - 1])) consonants++;
                    else dict[word[i + windowSize - 1]]++;

                    if (dict['a'] > 0 && dict['e'] > 0 && dict['i'] > 0 && dict['o'] > 0 && dict['u'] > 0 && consonants == k)
                    {
                        numStrings++;
                        break;
                    }
                }
            }

            return numStrings;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.countOfSubstrings(Globals.word, Globals.k));
            return;
        }
    }
}