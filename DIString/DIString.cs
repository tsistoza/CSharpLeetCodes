// LeetCode 2375
using System;
using System.Linq;
using System.Collections.Generic;

public static class Globals
{
    public static string pattern = "DDD";
}

namespace Solution
{
    public class Program
    {
        private void Backtrack(List<string> strings, List<int> bucket, string soln, string pattern, int size)
        {
            if (soln.Length == size)
            {
                strings.Add(soln);
                return;
            }

            for (int i=0; i<bucket.Count; i++)
            {
                string temp = soln;
                temp += bucket[i].ToString();
                List<int> newBucket = new List<int>(bucket);
                newBucket.RemoveAt(i);
                
                if (soln.Length == 0)
                {
                    Backtrack(strings, newBucket, temp, pattern, size);
                    continue;
                }

                if (pattern[temp.Length - 2] == 'D' && temp[temp.Length - 2] < temp[temp.Length - 1]) continue;
                if (pattern[temp.Length - 2] == 'I' && temp[temp.Length - 2] > temp[temp.Length - 1]) continue;
                Backtrack(strings, newBucket, temp, pattern, size);
            }
            return;
        }
        public string SmallestNumber(string pattern)
        {
            List<string> strings = new List<string>();
            Backtrack(strings, Enumerable.Range(1, pattern.Length+1).ToList(), "", pattern, pattern.Length+1);
            strings.Sort();
            return strings.First();
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.SmallestNumber(Globals.pattern));
            return;
        }
    }
}