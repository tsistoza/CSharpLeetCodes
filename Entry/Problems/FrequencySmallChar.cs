// LeetCode 1170
using System;
using System.Collections.Generic;

namespace _1170
{
    public static class Globals
    {
        public static string[] queries = { "cbd" };
        public static string[] words = { "zaaaz" };
    }
    public class Program
    {
        public int[] NumSmallerByFrequency(string[] queries, string[] words)
        {
            int[] freqCount = new int[words.Length];
            char smallestChar = (char)122;

            for (int i=0; i<words.Length; i++) freqCount[i] = CountSmallestFreq(words[i], smallestChar);
            freqCount.Sort();

            int[] answers = new int[queries.Length];
            smallestChar = (char)122;
            for (int i=0; i<queries.Length; i++)
            {
                int smallestFreq = CountSmallestFreq(queries[i], smallestChar);
                int low = 0;
                int high = words.Length - 1;
                while (low < high)
                {
                    int mid = low + (high - low) / 2;
                    if (freqCount[mid] <= smallestFreq)
                        low = mid + 1;
                    else if (freqCount[mid] > smallestFreq)
                        high = mid - 1;
                }

                answers[i] = words.Length - low;
            }

            PrettyPrint(answers);
            return answers;
        }

        private int CountSmallestFreq(string word, char smallestChar)
        {
            int smallestFreq = 0;
            foreach (char c in word)
            {
                if (c < smallestChar)
                {
                    smallestChar = c;
                    smallestFreq = 0;
                }

                if (c == smallestChar)
                    smallestFreq++;
            }

            return smallestFreq;
        }

        private static void PrettyPrint(int[] answers)
        {
            Console.Write("[ ");
            foreach (int i in answers)
                Console.Write($"{i} ");
            Console.WriteLine("]\n\n");
            return;
        }
    }
}
