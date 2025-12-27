// LeetCode 1014
using System;
using System.Collections.Generic;

namespace _1014
{
    public static class Globals
    {
        public static int[] values = { 8, 1, 5, 2, 6 };
    }
    public class Program
    {
        public int MaxScoreSightseeingPair(int[] values)
        {
            int maxScore = int.MinValue;
            for (int i=0; i<values.GetLength(0); i++)
            {
                for (int j=i+1; j<values.GetLength(0); j++)
                {
                    int currentScore = values[j] + values[i] - (j - i);
                    maxScore = (maxScore < currentScore) ? currentScore : maxScore;
                }
            }
            return maxScore;
        }
    }
}
