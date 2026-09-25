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
            int strLen = s.Length;
            if (strLen == 1) return s;

            // Count chars, and check which is the odd one
            int[] charFreq = new int[s.Length];
            foreach (char c in s)
                charFreq[(int)(c-'a')]++;

            char[] result = new char[s.Length];
            // Construct first half of string
            int ptr1 = 0, ptr2 = strLen - 1;
            for (int i=0; i<charFreq.Length; i++)
            {
                if (charFreq[i] == 0) continue;

                int num = charFreq[i] / 2; // Number of chars to repeat, Ex. if we have 4 A's, we repeat twice, and save 2 for other half

                while (num > 0)
                {
                    char append = (char)(i + 'a');
                    result[ptr1++] = append;
                    result[ptr2--] = append;
                }
            }

            if (strLen % 2 == 1) result[strLen / 2] = s[strLen / 2];
            return new string(result);
        }
    }
}
