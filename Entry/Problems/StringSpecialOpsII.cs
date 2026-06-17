// LeetCode 3614
using System;
using System.Collections.Generic;

namespace _3614
{
    public static class Globals
    {
        public static string s = "a#b%*";
        public static int k = 1;
    }

    public class Program
    {
        public char ProcessStr(string s, long k)
        {
            long length = 0;
            foreach (char c in s)
            {
                switch (c)
                {
                    case '*': length--;
                        break;
                    case '#': length *= 2;
                        break;
                    case '%':
                        break;
                    default: length++;
                        break;
                }
            }

            if (k > length) return '.';

            long currK = k;
            for (int i=s.Length-1; i>=0; i--)
            {
                switch (s[i])
                {
                    case '*': length++;
                        break;
                    case '#': length /= 2;
                        if (currK - length >= 0) currK -= length;
                        break;
                    case '%': currK = length - currK - 1;
                        break;
                    default: length--;
                        break;
                }
                //Console.WriteLine($"operation = {s[i]}, length = {length}, k={currK}");
            }
            return s[(int)currK];
        }
    }
}
