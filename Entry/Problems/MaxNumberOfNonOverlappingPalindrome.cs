using System;
using System.Collections.Generic;

namespace _2472
{
    public static class Globals
    {
        public static string s = "adbcda";
        public static int k = 2;
    }
    public class Program
    {
        public int MaxPalindromes(string s, int k)
        {
            int n = s.Length;
            int[] array = new int[n]; // Saves the beginning of a palin, so array[end] = begin, where end >= begin
            Array.Fill(array, -1);

            // FIND ALL PALINDROMES OF SIZE K or K+1, DONT CARE ABOUT K+2 and beyond....
            for (int center=0; center<n; center++)
            {
                int radius = 0;
                while (radius <= center && center < n - radius && s[center - radius] == s[center + radius]) // find palindrome from a center with radius, [L,...,C,...,R] -> Radius = R - C
                {
                    if (2 * radius + 1 >= k)
                    {
                        array[center + radius] = center - radius;
                        break;
                    }
                    radius++;
                }

                // If palindrome has an even number of chars
                int left = center;
                int right = center + 1;
                while (left >= 0 && right < n && s[left] == s[right])
                {
                    if (k <= right - left + 1)
                    {
                        array[right] = left;
                        break;
                    }
                    left--;
                    right++;
                }
            }

            int end = n - 1;
            int ans = 0;
            while(end - k + 1 >= 0)
            {
                if (array[end] == -1) // no palindrome with this end
                {
                    end--;
                    continue;
                }

                // There is a palindrome with this ending with length of at least (k or k + 1), set the end to begin - 1 (for no overlap)
                ans++;
                end = array[end] - 1;
            }
            return ans;
        }
    }
}
