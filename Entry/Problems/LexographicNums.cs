// LeetCode 386
using System;
using System.Collections.Generic;

namespace _386
{
    public static class Globals
    {
        public static int n = 50;
    }
    public class Program
    {
        public static void PrettyPrint(IList<int> ans)
        {
            Console.Write("{ ");
            foreach (int i in ans) Console.Write($"{i}, ");
            Console.WriteLine("}");
            return;
        }

        private void GetOrder(int i, int tight, ref List<int> ans)
        {
            int curr = i * 10;
            int check = i * 10;
            while (curr <= tight)
            {
                ans.Add(curr);
                curr++;
                if (curr - check >= 10)
                {
                    curr = check * 10;
                    check *= 10;
                }
            }
            return;
        }
        public IList<int> LexicalOrder(int n)
        {
            List<int> ans = new List<int>();
            int limit = (n < 10) ? n : 9;

            for (int i = 1; i <= limit; i++)
            {
                ans.Add(i);
                GetOrder(i, n, ref ans);
            }
            return ans;
        }
    }
}