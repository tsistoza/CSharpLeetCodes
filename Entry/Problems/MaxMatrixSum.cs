// LeetCode 1975
using System;
using System.Collections.Generic;

namespace _1975
{
    public static class Globals
    {
        public static List<List<int>> matrix = new List<List<int>>()
        {
            new List<int> { 1, -1 },
            new List<int> { -1, 1 }
        };
    }

    public class Program
    {
        public long MaxMatrixSum(List<List<int>> matrix)
        {
            int absSum = 0; // Maximum possible sum such that every number is positive
            int countNegative = 0;
            int minElement = matrix[0][0];

            // At first it sounds hard, however it is pretty easy. First of all, disregard the adjacency of elements. We know that if the negative number count is even
            // Then for n operations, it is possible to get all numbers in matrix positive, if the negative number count is odd, then there is at least one number that will
            // still be negative, for n operations. This is the number you want to minimize to maximize the sum.

            foreach (List<int> row in matrix)
            {
                foreach (int num in row)
                {
                    if (num < 0) countNegative++;
                    absSum += Math.Abs(num);
                    minElement = (minElement > Math.Abs(num)) ? num : minElement;
                }
            }

            if (countNegative % 2 == 0) return absSum; // For n operations, all numbers on matrix will be positive

            return absSum-(minElement*2); // For n operations, one number will be negative, subtract from the sum.
        }
    }
}