using System;
using System.Collections.Generic;
using System.Text;

namespace _3418
{
    public static class Globals
    {
        public static int[,] coins = { { -23, 19, 22, -6, -9 } };
    }
    public class Program
    {
        private void FillArray(ref int[,,] array, int value)
        {
            for (int i=0; i<array.GetLength(0); i++)
                for (int j=0; j<array.GetLength(1); j++)
                    for (int k=0; k<array.GetLength(2); k++)
                        array[i, j, k] = value;
            return;
        }
        public int MaximumAmount(int[,] coins)
        {
            int row = coins.GetLength(0);
            int col = coins.GetLength(1);

            // Note* - there is a possiblity that you wont need to use your special abilities
            int[,,] dp = new int[row, col, 3]; // [i, j, k] state is the robots max profit at cell i,j --> k is num times we have used special ability (neutralize)
            FillArray(ref dp, int.MinValue);

            dp[0, 0, 0] = coins[0, 0];
            dp[0, 0, 1] = 0;
            dp[0, 0, 2] = int.MinValue; // We cant neutralize 2 times since its the start, just set it to lowest possible value

            // Left Border
            for (int i=1; i<row; i++)
            {
                dp[i, 0, 0] = dp[i - 1, 0, 0] + coins[i, 0];
                dp[i, 0, 1] = Math.Max(dp[i - 1, 0, 1] + coins[i, 0], dp[i - 1, 0, 0]); // Max profit --> max between using special ability, or just adding the coins to profit
                dp[i, 0, 2] = Math.Max(dp[i - 1, 0, 2] + coins[i, 0], dp[i - 1, 0, 1]);
            }

            // Right Border
            for (int i=1; i<col; i++)
            {
                dp[0, i, 0] = dp[0, i - 1, 0] + coins[0, i];
                dp[0, i, 1] = Math.Max(dp[0, i - 1, 1] + coins[0, i], dp[0, i - 1, 0]);
                dp[0, i, 2] = Math.Max(dp[0, i - 1, 2] + coins[0, i], dp[0, i - 1, 1]);
            }

            // Fill Rest Of DP Table
            for (int i=1; i<row; i++)
            {
                for (int j=1; j<col; j++)
                {
                    dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i, j - 1, 0]) + coins[i, j];
                    
                    int firstCmp  = Math.Max(dp[i - 1, j, 1], dp[i, j - 1, 1]) + coins[i, j];
                    int secondCmp = Math.Max(dp[i - 1, j, 0], dp[i, j - 1, 0]); // Neutralize robber (1st neutralize), it doesnt matter if its not a robber (coins[i,j] < 0), since we always want the max profit anyway
                    dp[i, j, 1] = Math.Max(firstCmp, secondCmp);

                    firstCmp = Math.Max(dp[i - 1, j, 2], dp[i, j - 1, 2]) + coins[i, j];
                    secondCmp = Math.Max(dp[i - 1, j, 1], dp[i, j - 1, 1]); // Neutralize Robber (2nd neutralize)
                    dp[i, j, 2] = Math.Max(firstCmp, secondCmp);
                }
            }

            // Return the max between dp[row-1, col-1, 0], dp[row-1, col-1, 1], dp[row-1, col-1, 2]
            int firstAns = Math.Max(dp[row - 1, col - 1, 0], dp[row - 1, col - 1, 1]);
            return Math.Max(firstAns, dp[row - 1, col - 1, 2]);
        }
    }
}
