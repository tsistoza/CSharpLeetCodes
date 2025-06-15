// LeetCode 1432
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int num = 9;
}

namespace Solution
{
    public class Program
    {
        public int MaxDiff(int num)
        {
            string ctrl = num.ToString();

            // Maximize
            long a = 0;
            long multiplicand = (long)Math.Pow(10, ctrl.Length-1);
            int leading = ctrl[0] - 48;
            for (int i=0, replace=-1; i < ctrl.Length; i++, multiplicand/=10) // Always choose y=9
            {
                if (replace == -1 && ctrl[i] - 48 != 9) replace = ctrl[i] - 48;
                if (ctrl[i]-48 == replace) a += (9 * multiplicand);
                else a += (ctrl[i] - 48) * multiplicand;
            }

            // Minimize
            long b = 0;
            multiplicand = (long)Math.Pow(10, ctrl.Length - 1);

            if (num < 10) b = 1; // Edge Case
            
            if (num >= 10 && leading == 1) // Edge Case, replace with y=0
            {
                for (int i=0, replace=-1; i<ctrl.Length; i++, multiplicand/=10)
                {
                    if (ctrl[i] - 48 == leading)
                    {
                        b += (ctrl[i] - 48) * multiplicand;
                        continue;
                    }
                    if (replace == -1 && ctrl[i]-48 != 0) replace = ctrl[i] - 48;

                    if (ctrl[i]-48 == replace) continue;
                    else b += (ctrl[i] - 48) * multiplicand;
                }

                b = (b == 0) ? num : b;
            } else if (num >= 10 && leading > 1) // set first y=1, y!=0
            {
                for (int i=0; i<ctrl.Length; i++, multiplicand/=10)
                {
                    if (ctrl[i] - 48 == leading) b += (1 * multiplicand);
                    else b += (ctrl[i] - 48) * multiplicand;
                }
            }

            
            return (int) Math.Abs((b - a));
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxDiff(Globals.num));
            return;
        }
    }
}