// LeetCode 343
using System;
using System.Collections.Generic;


namespace _343
{
    public static class Globals
    {
        public static int n = 5;
    }

    public class Program
    {
        public int IntegerBreak(int n)
        {
            int[] dp = new int[n+1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
            for (int i=3; i<=n; i++)
            {
                int maxIndex = ((i - 1) / 2); // Start in the middle
                int tempAns = 0;
                for (int j=maxIndex; j<=maxIndex+1; j++) // Find the max product
                {
                    int multiplier = Math.Abs(j - i);

                    // Note when finding dp[i], past answers of dp[i] dont always give you the max product
                    // Ex. 4 => 2*2 => dp[2]*dp[2] = 1 < (2*2)
                    tempAns = Math.Max(tempAns, Math.Max(j, dp[j]) * Math.Max(multiplier, dp[multiplier]) );
                }

                dp[i] = tempAns;
                Console.WriteLine($"dp[{i}] = {dp[i]}");
            }
            return dp[n];
        }
    }
}

/* Intuition
 * 
 * 2 => 1*1 => 1
 * 3 => 2*1 => 2
 * 4 => 2*2 => 4
 * 5 => 3*2 => 5
 * 6 => 3*3 => 9
 * 8 => 3*5 => 3*3*2
 * 9 => 3*6 => 3*3*3
 * 
 * dp[i] represents the max product at a given sum i.
 * Lets take a look at 4 => 1*3,(2*2),3*1 notice in the middle is the one with the highest product
 * 10 => 1*9,2*8,3*7,4*6,(5*5),6*4,7*3,8*2,9*1 => 5*5 will yield the highest answer
 * And that also applies to the rest since we can split the number multiple times resulting in more splits, resulting in a high product.
 * 
 * So all we need to do is find that (NOTE its somewhere in the middle)
 * 
 * 10 => 5*5 => dp[5]*dp[5] => (3*2*3*2) => 36
 */