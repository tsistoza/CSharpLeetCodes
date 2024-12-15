// LeetCode 1792
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<List<int>> classes = new List<List<int>>()
    {
        new List<int> { 1, 2 },
        new List<int> { 3, 5 },
        new List<int> { 2, 2 }
    };
    public static int extraStudents = 2;
    public static List<List<int>> classes1 = new List<List<int>>()
    {
        new List<int> { 2, 4 },
        new List<int> { 3, 9 },
        new List<int> { 4, 5 },
        new List<int> { 2, 10 }
    };
    public static int extraStudents1 = 4;
}

namespace Solution
{
    public class Program
    {
        public double MaxAverageRatio(List<List<int>> classes, int extraStudents)
        {
            SortedDictionary<float, int> kvp = new SortedDictionary<float, int>();
            List<float> ratios = new List<float>();
            for (int i = 0; i < classes.Count; i++)
            {
                float currentRatio = (float) classes[i][0] / (float) classes[i][1];
                float newRatio = (float) (classes[i][0] + 1) / (float) (classes[i][1] + 1);
                ratios.Add(currentRatio);
                float gain = newRatio - currentRatio;
                kvp.Add(gain, i);
            }
            while (extraStudents > 0)
            {
                List<float> val = new List<float>(kvp.Keys);
                int index = kvp[val[val.Count - 1]];
                classes[index][0]++;
                classes[index][1]++;
                float newGain =  ((float) classes[index][0] + 1 / (float) classes[index][1] + 1) - ((float)classes[index][0] / (float)classes[index][1]);
                kvp.Remove(val[val.Count - 1]);
                kvp.Add(newGain, index);
                ratios[index] = (float)classes[index][0] / (float)classes[index][1];
                extraStudents--;
            }
            double sum = 0;
            foreach(float ratio in ratios)
                sum += ratio;
            sum /= classes.Count;
            return sum;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxAverageRatio(Globals.classes, Globals.extraStudents));
            Console.WriteLine(obj.MaxAverageRatio(Globals.classes1, Globals.extraStudents1));
            return;
        }
    }
}

