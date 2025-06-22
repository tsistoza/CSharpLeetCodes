// LeetCode 3443
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string s = "NSWWEW";
    public static int k = 3;
}

namespace Solution
{
    public class Program
    {
        public int MaxDistance(string s, int k)
        {
            int countN = 0, countS = 0, countE = 0, countW = 0;
            int ans = 0;
            for (int i=0; i<s.Length; i++)
            {
                if (s[i] == 'N') countN++;
                if (s[i] == 'S') countS++;
                if (s[i] == 'E') countE++;
                if (s[i] == 'W') countW++;

                int modNS = Math.Min(Math.Min(countN, countS), k);
                int modWE = Math.Min(Math.Min(countW, countE), k - modNS);

                int manDistNS = Math.Abs(countN - countS) + (2 * modNS);
                int manDistWE = Math.Abs(countW - countE) + (2 * modWE);

                ans = Math.Max(ans, manDistNS + manDistWE);
            }
            return ans;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxDistance(Globals.s, Globals.k));
            return;
        }
    }
}