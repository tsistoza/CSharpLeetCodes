// LeetCode 955
using System;
using System.Collections.Generic;

namespace _955
{
    public static class Globals
    {
        public static string[] strs = { "zyx", "wvu", "tsr" };
    }

    public class Program
    {
        public int MinDeletionSize(string[] strs)
        {
            int deleteCount = 0;
            int strLength = strs[0].Length;

            for (int i=0; i<strLength; i++)
            {
                for (int j=1; j<strs.Length; j++)
                {
                    if (strs[j-1][i] > strs[j][i])
                    {
                        deleteCount++;
                        break;
                    }
                    return deleteCount;
                }
            }
            return deleteCount;
        }
    }
}
