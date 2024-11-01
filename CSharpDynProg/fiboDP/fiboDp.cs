using System;

namespace Solution
{
    public class Program
    {
        public static int fibonacii(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
            for(int i=3; i<=n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];
            return dp[n];
        }

        public static void Main()
        {
            Console.WriteLine(fibonacii(3));
            return;
        }
    }
}