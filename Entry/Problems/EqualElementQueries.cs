// LeetCode 3488
using System;
using System.Collections.Generic;

namespace _3488
{
    public static class Globals
    {
        public static int[] nums = { 1, 2, 3, 4 };
        public static int[] queries = { 0, 1, 2, 3 };
    }
    public class Program
    {
        private void PrettyPrint(IList<int> answers)
        {
            Console.Write("Answers: { ");
            foreach(int answer in answers)
                Console.Write($"{answer} ");
            Console.WriteLine("}\n\n");
            return;
        }
        public IList<int> SolveQueries(int[] nums, int[] queries)
        {
            Dictionary<int, List<int>> positions = new Dictionary<int, List<int>>();
            for (int i=0; i<nums.Length; i++)
            {
                if (!positions.TryAdd(nums[i], new List<int> { i }))
                    positions[nums[i]].Add(i);
            }

            int[] answers = new int[queries.Length];
            Array.Fill(answers, int.MaxValue);
            for (int i=0; i<queries.Length; i++)
            {
                int number = nums[queries[i]];
                if (positions[number].Count == 1)
                {
                    answers[i] = -1;
                    continue;
                }
                foreach (int index in positions[number])
                {
                    if (index == queries[i]) continue;
                    int lowIndex = Math.Min(index, queries[i]);
                    int highIndex = Math.Max(index, queries[i]);

                    int forward = Math.Abs(lowIndex - highIndex);
                    int backward = Math.Abs(highIndex - (lowIndex + nums.Length));
                    int currAns = Math.Min(forward, backward);

                    answers[i] = Math.Min(answers[i], currAns);
                }
            }

            PrettyPrint(answers);
            return answers;
        }
    }
}
