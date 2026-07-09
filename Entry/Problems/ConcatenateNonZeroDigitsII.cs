// LeetCode 3756
using System;
using System.Collections.Generic;

namespace _3756
{
    public static class Globals
    {
        public static string s = "9876543210";
        public static int[][] queries = new int[1][]
        {
            new int[2] { 0, 9 }
        };
    }
    public class Program
    {
        private void PrettyPrint(int[] result)
        {
            Console.Write("{");
            foreach (int i in result) Console.Write($" {i}");
            Console.WriteLine(" }\n");
            return;
        }
        private int CalculateXAndSum(int[] prefix, Dictionary<int, int> position, string prefixConcat, int left, int right)
        {
            long sum = 0, x = 0;
            if (left == 0) sum = prefix[right];
            else sum = prefix[right] - prefix[left - 1];

            int low = (position[left] < left) ? position[left] + 1 : position[left];
            int high = position[right];

            //Console.WriteLine($"prefix = {prefixConcat}, low = {low}, high={high}");
            if (low > high) x = (int)prefixConcat[high] - 48;
            else
            {
                int num = (int)Math.Pow(10, high - low);
                for (int i = low; i <= high; i++, num /= 10)
                    x += ((int)prefixConcat[i] - 48) * num;
            }

            //Console.WriteLine($"x = {x}, sum = {sum}");

            return (int)((x * sum) % ((int)Math.Pow(10, 9) + 7));
        }
        public int[] SumAndMultiply(string s, int[][] queries)
        {
            int[] prefix = new int[s.Length];

            string prefixConcat = "";
            Dictionary<int, int> position = new Dictionary<int, int>();
            for (int i=0; i<s.Length; i++)
            {
                int digit = (int)s[i] - 48;

                if (i == 0) prefix[i] = digit;
                else prefix[i] = prefix[i - 1] + digit;

                if (digit > 0)
                    prefixConcat += s[i];

                position.Add(i, prefixConcat.Length - 1); // save the closest nonzero position
            }


            // Process queries
            int[] result = new int[queries.Length];
            for (int i=0; i<queries.Length; i++)
            {
                int left = queries[i][0], right = queries[i][1];
                int ans = CalculateXAndSum(prefix, position, prefixConcat, left, right);
                result[i] = ans;
            }

            PrettyPrint(result);
            return result;
        }
    }
}
