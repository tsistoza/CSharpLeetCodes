// LeetCode 3517
using System;
using System.Collections.Generic;

namespace _3517
{
    public static class Globals
    {
        public static string s = "babab";
    }

    public class Program
    {
        private string ReverseString(string substring)
        {
            string reversed = string.Empty;
            for (int i=substring.Length-1; i>=0; i--)
                reversed += substring[i];
            return reversed;
        }
        public string SmallestPalindrome(string s)
        {
            if (s.Length == 1) return s;

            // Count chars, and check which is the odd one
            SortedDictionary<char, int> numChars = new SortedDictionary<char, int>();
            foreach (char c in s)
            {
                if (!numChars.ContainsKey(c)) numChars.Add(c, 1);
                else numChars[c]++;
            }

            string result = "";
            // Construct first half of string
            char mid = 'a';
            foreach (char c in numChars.Keys)
            {
                if (numChars[c] % 2 == 1) // if we have an odd number than thats the middle char
                    mid = c;

                int num = numChars[c] / 2; // Number of chars to repeat, Ex. if we have 4 A's, we repeat twice, and save 2 for other half
                if (num == 0) continue;

                string repeated = new string(c, num);
                result += repeated;
            }

            // Construct the second half of string
            string reversed = ReverseString(result); // Reverse the first half of the string
            if (s.Length % 2 == 1) result += mid;
            result += reversed;
            return result;
        }
    }
}
