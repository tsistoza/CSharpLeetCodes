// LeetCode 1079
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string tiles = "AAB";
    public static string tiles1 = "AAABBC";
    public static string tiles2 = "V";
}

namespace Solution
{
    public class Program
    {
        // Generate The PowerSet. Make sure the powerset has no duplicates. Then find every permutation for each powerSet.
        private void generatePowerset(List<string> powerSet, HashSet<string> dict, string curr, string tiles, int index)
        {
            if (!dict.Contains(curr) && curr.Count() > 0)
            {
                dict.Add(curr);
                powerSet.Add(curr);
            }

            if (index >= tiles.Count()) return;

            string temp = curr;
            temp += new String (tiles[index], 1);
            generatePowerset(powerSet, dict, temp, tiles, index + 1);

            if (curr.Count() == 0) return;

            string temp1 = curr;
            temp1 = temp1.Remove(temp1.Count() - 1, 1);
            temp1 += new String (tiles[index], 1);
            generatePowerset(powerSet, dict, temp1, tiles, index + 1);
            return;
        }
        private void generatePermutations(string curr, HashSet<string> dict, int index)
        {
            if (!dict.Contains(curr)) dict.Add(curr);
            if (index >= curr.Count()) return;
            
            char[] currArr = curr.ToCharArray();
            for (int i = index; i<curr.Count(); i++)
            {
                char swap = currArr[index];
                currArr[index] = currArr[i];
                currArr[i] = swap;
                generatePermutations(new String (currArr), dict, index + 1);
            }
            return;
        }
        public int numTilePossiblities(string tiles)
        {
            if (tiles.Count() == 1) return 1;

            HashSet<string> dict = new HashSet<string>();
            List<string> powerSet = new List<string>();
            generatePowerset(powerSet, dict, new String('a', 0), tiles, 0);

            foreach (string tile in powerSet)
            {
                if (tile.Count() <= 1) continue;
                generatePermutations(tile, dict, 0);
            }
            return dict.Count();
        }
        
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.numTilePossiblities(Globals.tiles));
            Console.WriteLine(obj.numTilePossiblities(Globals.tiles1));
            Console.WriteLine(obj.numTilePossiblities(Globals.tiles2));
            return;
        }
    }
}