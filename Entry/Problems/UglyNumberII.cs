// LeetCode 264
using System;
using System.Collections.Generic;

namespace _264
{
    public static class Globals
    {
        public static int n = 10;
    }
    public class Program
    {
        private List<int> makeList(ref List<int> dp, int idx)
        {

            List<int> newList = new List<int>() { dp[idx] * 2, dp[idx] * 3, dp[idx] * 5 };
            return newList;
        }
        public int NthUglyNumber(int n)
        {
            List<int> dp = new List<int>();
            for (int i = 0; i < 3; i++) dp.Add(i + 1);

            List<int> l1 = makeList(ref dp, 0);
            List<int> l2 = makeList(ref dp, 1);
            List<int> l3 = makeList(ref dp, 2);
            int nxtIdx = 3;

            while (dp.Count < n)
            {
                Console.WriteLine($"l1={l1.Count}, l2={l2.Count}, l3={l3.Count}");

                if (l1.Count == 0)
                {
                    l1 = makeList(ref dp, nxtIdx);
                    nxtIdx++;
                }
                if (l2.Count == 0)
                {
                    l2 = makeList(ref dp, nxtIdx);
                    nxtIdx++;
                }
                if (l3.Count == 0)
                {
                    l3 = makeList(ref dp, nxtIdx);
                    nxtIdx++;
                }

                int nxtUglyNumber = Math.Min(l1[0], Math.Min(l2[0], l3[0]));
                if (nxtUglyNumber <= dp[dp.Count - 1])
                {
                    if (nxtUglyNumber == l1[0]) l1.RemoveAt(0);
                    if (nxtUglyNumber == l2[0]) l2.RemoveAt(0);
                    if (nxtUglyNumber == l3[0]) l3.RemoveAt(0);
                    continue;
                }

                dp.Add(nxtUglyNumber);
                if (nxtUglyNumber == l1[0]) l1.RemoveAt(0);
                if (nxtUglyNumber == l2[0]) l2.RemoveAt(0);
                if (nxtUglyNumber == l3[0]) l3.RemoveAt(0);
            }

            return dp[n-1];
        }
    }
}
