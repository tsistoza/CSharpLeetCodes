// LeetCode 2554
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] banned = { 1, 6, 5 };
    public static int n = 5;
    public static int maxSum = 6;
    public static int[] banned1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public static int n1 = 8;
    public static int maxSum1 = 1;
    public static int[] banned2 = { 11 };
    public static int n2 = 7;
    public static int maxSum2 = 50;

}

namespace Solution
{
    public class Compare : IComparer<List<int>>
    {
        int IComparer<List<int>>.Compare(List<int>? a, List<int>? b )
        {
            if (a!.Count < b!.Count) return 1;
            if (a.Count > b.Count) return -1;
            return 0;
        }
    }
    public class Program
    {
        private bool isBanned(int[] banned, int num)
        {
            for (int i = 0; i < banned.Length; i++)
                if (banned[i] == num) return true;
            return false;
        }
        public int MaxCount(int[] banned, int n, int maxSum)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> choose = new List<int>();
            for (int i = 1; i <= n; i++)
                if (!isBanned(banned, i)) choose.Add(i);   
            if (choose.Count <= 0) return 0;

            // Split into subproblems, here we anchor one number, and then keep adding the other numbers in the list one by one, until we reach the end or > maxSum
            // Remember each time you add a number to the list, and it is <= maxSum, then that is an answer to a subproblem.
            // Ex: List choose = 1, 2, 3, 4 maxSum=10
            // Anchor 1, List=1 -> List=1,2 -> List=1,2,3 -> List=1,2,3,4
            for (int i = 0; i<choose.Count; i++)
            {
                int sum = choose[i];
                List<int> sub = new List<int>();
                sub.Add(choose[i]);
                for (int j = i+1; j<choose.Count; j++)
                {
                    sum += choose[j];
                    if (sum > maxSum) break;
                    sub.Add(choose[j]);
                    result.Add(new List<int>(sub));
                }
            }

            // You cannot choose any integers
            if (result.Count == 0) return 0;

            // Sort subproblems
            if (result.Count > 1)
            {
                Compare cmp = new Compare();
                result.Sort(cmp);
            }
            return result[0].Count; // return the maxNum of integers
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxCount(Globals.banned, Globals.n, Globals.maxSum));
            Console.WriteLine(obj.MaxCount(Globals.banned1, Globals.n1, Globals.maxSum1));
            Console.WriteLine(obj.MaxCount(Globals.banned2, Globals.n2, Globals.maxSum2));
            return;
        }
    }
}