// LeetCode 49
using System;
using System.Collections.Generic;

namespace _49
{
    public static class Globals
    {
        public static List<string> strs = new List<string>() { "a" };
    }
    public class Program
    {
        public static void prettyPrint(List<List<string>> list)
        {
            Console.Write("{");
            for (int i=0; i<list.Count; i++)
            {
                Console.Write("{ ");
                for (int j=0; j<list[i].Count; j++)
                    Console.Write($"{list[i][j]}, ");
                Console.Write("} ");
            }
            Console.WriteLine("}");
            return;
        }
        private Dictionary<char, int> generateDictionary(string c)
        {
            Dictionary<char, int> lettercount = new Dictionary<char, int>();
            for (int i=0; i<c.Length; i++)
            {
                if (lettercount.ContainsKey(c[i])) lettercount[c[i]]++;
                else lettercount.Add(c[i], 1);
            }
            return lettercount;
        }
        public List<List<string>> groupAnagrams(List<string> strs)
        {
            List<List<string>> results = new List<List<string>>();
            
            while(strs.Count > 0)
            {
                List<string> result = new List<string>(){ strs[0] };
                Dictionary<char, int> letterCount1 = generateDictionary(strs[0]);
                strs.RemoveAt(0);
                for (int i=0; i<strs.Count; )
                {
                    int count = 0;
                    Dictionary<char, int> letterCount2 = generateDictionary(strs[i]);
                    foreach (char c in letterCount1.Keys)
                    {
                        if (!letterCount2.ContainsKey(c)) break;
                        if (letterCount1[c] == letterCount2[c]) count++;
                    }
                    if (count != letterCount1.Keys.Count)
                    {
                        i++;
                        continue;
                    }
                    result.Add(strs[i]);
                    strs.Remove(strs[i]);
                }
                results.Add(result);
            }
            return results;
        }
    }
}