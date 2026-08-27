// LeetCodee 2904
using System;
using System.Collections.Generic;

namespace _2904
{
    public static class Globals
    {
        public static string s = "000";
        public static int k = 1;
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
        public string ShortestBeautifulSubstring(string s, int k)
        {
            if (k == 1)
            {
                foreach (char c in s)
                    if (c == '1') return "1";
                return "";
            }

            LinkedList<int> indexes = new LinkedList<int>();
            string minBeautifulString = "";
            for (int i = 0; i < s.Length; i++) minBeautifulString += '1';

            // Sliding Window, Whenever we find a beautiful string, we want to remove the first 1, and slide and minimize the window, to where we have k-1 1's
            // and increase p2 till we find k 1's again, this guarantees that with this substring, its always minimized
            int p1 = 0, p2 = 0, num1 = 0;
            while (p2 < s.Length)
            {
                if (s[p2] == '1')
                {
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

            return minBeautifulString;

        }
    }
}
