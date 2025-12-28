// LeetCode 2516
// Here is a video what I am going to implementing
// https://www.youtube.com/watch?v=QzcxeJZByNM&t=1s
using System;
using System.Collections.Generic;

namespace _2516
{
    public static class Globals
    {
        public static string s = "aabaaaacaabc";
        public static int k = 2;
    }
    public class Program
    {
        public int TakeCharacters(string s, int k)
        {
            Dictionary<char, int> numChars = new Dictionary<char, int>() { { 'a', 0 }, { 'b', 0 }, { 'c', 0 } };
            foreach (char c in s) numChars[c]++;
            if (numChars['a'] < k || numChars['b'] < k || numChars['c'] < k) return -1; // Check if string s is valid

            // Implementing a sliding window
            // The window is the characters left after you do the take aways
            // The idea is to maximize the windowSize such that, the takeaways are minimal
            int windowBegin = 0;
            int windowEnd = 0;
            List<int> windowSizes = new List<int>();

            while(windowEnd < s.Length)
            {
                if (isInvalid(s, windowBegin, windowEnd, k, numChars))
                {
                    int size = windowEnd - windowBegin;
                    windowSizes.Add(size);
                    windowBegin = ++windowEnd;
                } else windowEnd++;
            }

            if (windowSizes.Count == 0) return -1;
            windowSizes.Sort();
            return s.Length - windowSizes[windowSizes.Count-1];
        }

        // Checks if the characters outside the window are at least k, True if a,b,c count is < k, and false otherwise
        public bool isInvalid(string s, int windowBegin, int windowEnd, int k, Dictionary<char, int> numChars)
        {
            int numA = numChars['a'];
            int numB = numChars['b'];
            int numC = numChars['c'];
            for (int i = windowBegin; i<windowEnd+1; i++)
            {
                if (s[i] == 'a') numA--;
                if (s[i] == 'b') numB--;
                if (s[i] == 'c') numC--;
                if (numA < k || numB < k || numC < k) return true;
            }
            return false;
        }
    }
}
