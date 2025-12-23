// LeetCode 2014
using System;
using System.Collections.Generic;

namespace _2014
{
    public static class Globals
    {
        public static string s = "ab";
        public static int k = 2;
    }
    public class Program
    {
        private bool LexographicallyLarger(string newStr, string oldStr)
        {
            if (newStr.Length > oldStr.Length) return true;
            if (newStr.Length < oldStr.Length) return false;

            for (int i=0; i<newStr.Length; i++)
            {
                if (newStr[i] > oldStr[i]) return true;
                if (newStr[i] < oldStr[i]) return false;
            }

            return true;
        }

        private void BackTrack(string s, string newStr, int startIdx, int idx, int k, ref string result, Dictionary<string,(int x,int start,int end)> dict)
        {
            if (idx >= s.Length) return;

            if (newStr == "let") Console.WriteLine($"START = {startIdx}, END = {idx}");
            if (!dict.TryAdd(newStr, (1, startIdx, idx)))
            {
                if (startIdx <= dict[newStr].end) return;
                dict[newStr] = (dict[newStr].x + 1, dict[newStr].start, idx);
            }

            result = (dict[newStr].x >= k && LexographicallyLarger(newStr, result)) ? newStr : result;

            for (int i = idx + 1; i < s.Length; i++)
            {
                string addStr = newStr + s[i];
                BackTrack(s, addStr, startIdx, i, k, ref result, dict);

                string nxtStr = newStr;
                nxtStr = nxtStr.Remove(nxtStr.Length - 1) + s[i];

                if (nxtStr.Length == 1)
                    BackTrack(s, nxtStr, i, i, k, ref result, dict);
                else
                    BackTrack(s, nxtStr, startIdx, i, k, ref result, dict);

                
            }

            return;

        }
        public string LongestSubsequenceRepeated(string s, int k)
        {
            string result = "";

            Dictionary<string,(int,int,int)> dict = new Dictionary<string,(int,int,int)>();

            BackTrack(s, new String(s[0], 1), 0, 0, k, ref result, dict);

            return result;
        }
    }
}