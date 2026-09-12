// LeetCodee 2904
using System;
using System.Collections.Generic;

namespace _2904
{
    public static class Globals
    {
        public static string s = "0101111000101011001";
        public static int k = 9;
    }
    public class Program
    {
        private string LexographicallySmallestString(string s1, string s2)
        {
            if (s1.Length < s2.Length) return s1;
            if (s1.Length > s2.Length) return s2;

            // Lengths are equal
            int index = 0;
            while (index < s1.Length)
            {
                if (s1[index] < s2[index]) return s1;
                if (s1[index] > s2[index]) return s2;
                index++;
            }

            return s1;
        }
        private string CreateMaxString(int length)
        {
            string maxString = "";
            for (int i = 0; i < length; i++) maxString += '1';
            return maxString;
        }
        public string ShortestBeautifulSubstring(string s, int k)
        {
            if (k == 1)
            {
                foreach (char c in s)
                    if (c == '1') return "1";
                return "";
            }

            if (k == s.Length)
            {
                int numOnes = 0;
                foreach (char c in s) if (c == '1') numOnes++;
                return (numOnes == k) ? CreateMaxString(k) : "";
            }

            LinkedList<int> indexes = new LinkedList<int>();
            string minBeautifulString = CreateMaxString(s.Length);
            string cmp = minBeautifulString;

            // Sliding Window, Whenever we find a beautiful string, we want to remove the first 1, and slide and minimize the window, to where we have k-1 1's
            // and increase p2 till we find k 1's again, this guarantees that with this substring, its always minimized
            int p1 = 0, p2 = 0, num1 = 0;
            while (p2 < s.Length)
            {
                if (s[p2] == '1')
                {
                    p1 = (s[p1] == '0') ? p2 : p1;
                    indexes.AddLast(p2);
                    num1++;
                }


                if (num1 == k)
                {
                    minBeautifulString = LexographicallySmallestString(minBeautifulString, s.Substring(p1, p2 - p1 + 1));
                    num1--;
                    indexes.RemoveFirst();
                    p1 = indexes.First();
                }

                Console.WriteLine($"p1 = {p1}, p2 = {p2}, minString = {minBeautifulString}");

                p2++;
            }

            return (minBeautifulString == cmp) ? "" : minBeautifulString;

        }
    }
}
