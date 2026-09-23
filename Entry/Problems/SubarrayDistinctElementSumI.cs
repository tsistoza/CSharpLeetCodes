using System;
using System.Collections.Generic;

namespace _2913
{
    public static class Globals
    {
        public static List<int> nums = new List<int>() { 1, 2, 1 };
    }
    public class Program
    {
        private void UpdateTree(int[] tree, int index, int value, int n)
        {
            tree[index + n] = (int)Math.Pow(value, 2);

            int parentNode = (index + n) / 2;
            while (parentNode > 0)
            {
                tree[parentNode] = tree[parentNode * 2] + tree[parentNode * 2 + 1];
                parentNode = parentNode / 2;
            }
        }

        private int Query(int[] tree, int curr, int ql, int qr, int l, int r)
        {
            if (r < ql || l > qr) return 0;

            if (ql <= l && r <= qr) return tree[curr];

            int mid = (l + r) / 2;
            return Query(tree, curr * 2, ql, qr, l, mid) + Query(tree, curr * 2 + 1, ql, qr, mid + 1, r);
        }

        public int SumCounts(IList<int> nums)
        {
            int n = (nums.Count * (nums.Count + 1)) / 2;
            int[] distinct = new int[n];
            int[] tree = new int[2*n];
            for (int i=0, subarrayN=0; i<nums.Count; i++)
            {
                HashSet<int> freq = new HashSet<int>();
                for (int j = i; j < nums.Count; j++, subarrayN++)
                {
                    if (!freq.Contains(nums[j]))
                    {
                        freq.Add(nums[j]);
                        distinct[subarrayN]++;
                    }
                    if (j < nums.Count - 1) distinct[subarrayN + 1] = distinct[subarrayN];
                    UpdateTree(tree, subarrayN, distinct[subarrayN], n);
                    Console.WriteLine($"distinct[{subarrayN}] = {distinct[subarrayN]}");
                }
            }

            int ql = 2, qr = 5, l = 0, r = n - 1;
            Console.WriteLine($"ql = {ql}, qr={qr}, sum = {Query(tree, 1, ql, qr, l, r)}");

            return tree[1];
        }
    }
}
