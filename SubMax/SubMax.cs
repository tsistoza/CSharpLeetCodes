using System;
using System.Collections.Generic;

namespace Solution
{
    public static class Globals
    {
        public static readonly string s = "aa";
    }
    public class Program
    {
        private List<string> substrings = new List<string>();

        public int MaxUniqueSplit(string s)
        {
            char[] charArray = s.ToCharArray();
            findSubstrings(charArray);
            return this.substrings.Count;
        }

        private void readSubstrings(IEnumerable<string> list)
        {
            Console.WriteLine("Substrings:");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
            return;
        }

        private void findSubstrings(char[] charArray)
        {
            string s = "";
            for (int i=0; i<charArray.Length; i++)
            {
                s += charArray[i];
                if (!this.substrings.Contains(s))
                {
                    this.substrings.Add(s);
                    s = "";
                }
                if ( i == charArray.Length-1 && s != "")
                {
                    string lastString = this.substrings.Last();
                    s = lastString + charArray[i];
                    if (!this.substrings.Contains(s) && lastString != charArray[i].ToString())
                    {
                        this.substrings.Remove(lastString);
                        this.substrings.Add(s);
                    }
                } 
            }
            readSubstrings(substrings);
            return;
        }


        public static int Main()
        {
            Program obj = new Program();
            Console.WriteLine($"Max Number of Substrings is: {obj.MaxUniqueSplit(Globals.s)}");
            return 0;
        }
    }
}