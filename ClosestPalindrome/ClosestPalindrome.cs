// LeetCode 564
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string n = "123";
    public static string n1 = "1";
}

namespace Solution
{
    public class Program
    {
        private (bool, string?) isPalindrome(string n)
        {
            char[] reverse = n.ToCharArray();
            reverse.Reverse();
            string? rev = reverse.ToString();
            if (rev == null) return ( false, null );

            bool flag = true;
            string palindrome = "";
            int midPt = ((n.Length - 1) / 2);
            Console.WriteLine(midPt);
            for (int i=0; i<midPt+1; i++)
                palindrome += n[i];

            for (int i=0; i < midPt; i++)
            {
                if (reverse[i] != palindrome[i])
                    flag = false;
                palindrome += reverse[i];
            }
            return ( flag, palindrome );
        }

        public string NearestPalindromic(string n)
        {
            if (n.Length == 1)
            {
                int number = Convert.ToInt32(n);
                number--;
                return Convert.ToString(number);
            }

            (bool flag, string? palindrome) = this.isPalindrome(n);
            if (flag)
            {
                string newString = "";
                int midPt = (int)Math.Round((decimal)(palindrome!.Length - 1 / 2));
                for (int i=0; i<palindrome.Length; i++)
                {
                    if (i == midPt && palindrome[i] != '0')
                    {
                        newString += palindrome[i] - 1;
                        continue;
                    }
                    if (i == midPt && palindrome[i] == 0)
                    {
                        newString += palindrome[i] + 1;
                        continue;
                    }
                    newString += palindrome[i];
                }
                palindrome = newString;
            }
            return palindrome!;
        }
        
        public static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine(obj.NearestPalindromic(Globals.n));
            Console.WriteLine(obj.NearestPalindromic(Globals.n1));
            return;
        }
    }
}