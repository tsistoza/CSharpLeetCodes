// LeetCode 2466
using System;
using System.Collections.Generic;

namespace _2466
{
    public struct Inputs
    {
        public int low;
        public int high;
        public int zero;
        public int one;
    }
    public static class Globals
    {
        public static Inputs inputs = new Inputs()
        {
            low = 3, 
            high = 3, 
            zero = 1, 
            one = 1
        };
    }
    public class Program
    {
        public void dfs(string clone, Inputs inputs, List<string> goodStrings)
        {
            if (clone.Length >= inputs.low && clone.Length <= inputs.high)
                goodStrings.Add(clone);

            if (clone.Length > inputs.high) return;

            string temp = clone;
            for (int i = inputs.zero; i > 0; i--)
                temp += "0";
            dfs(temp, inputs, goodStrings);

            temp = clone;
            for (int i = inputs.one; i > 0; i--)
                temp += "1";
            dfs(temp, inputs, goodStrings);

            return;
        }
        public int CountGoodStrings(Inputs inputs)
        {
            List<string> goodStrings = new List<string>();
            dfs("", inputs, goodStrings);
            return goodStrings.Count;
        }
        
    }
}
