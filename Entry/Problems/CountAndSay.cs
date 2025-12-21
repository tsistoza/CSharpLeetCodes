// LeetCode 38
using System;
using System.Collections.Generic;

namespace _38
{
    public static class Globals
    {
        public static int n = 5;
    }
    public class Program
    {
        public string CountAndSay(int n)
        {
            if (n == 1)
                return "1";
            if (n == 2)
                return "11";

            string rle = CountAndSay(n - 1);
            string newRle = "";
            char c = rle[0];
            int count = 1;
            for (int i=1; i<=rle.Length; i++)
            {
                if (i == rle.Length)
                {
                    newRle += Convert.ToString(count) + c;
                    break;
                }
                if (c != rle[i])
                {
                    newRle += Convert.ToString(count) + c;
                    count = 1;
                    c = rle[i];
                    continue;
                }
                count++;
            }
            return newRle;
        }
    }
}