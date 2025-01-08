// LeetCode 1947
using System;
using System.Collections.Generic;

public static class Globals
{
    public static List<List<int>> students = new List<List<int>>()
    {
        new List<int>() { 1, 1, 0 },
        new List<int>() { 1, 0, 1 },
        new List<int>() { 0, 0, 1 }
    };
    public static List<List<int>> mentors = new List<List<int>>()
    {
        new List<int>() { 1, 0, 0 }, new List<int>() { 0, 0, 1 }, new List<int>() { 1, 1, 0 }
    };
}

namespace Solution
{
    public class Program
    {
        private int CompatibilityScore(List<int> student, List<int> mentor)
        {
            int sum = 0;
            for (int i=0; i<student.Count; i++)
                if (student[i] == mentor[i]) sum++;
            return sum;
        }
        private void dfs (ref int max, int sum, List<List<int>> students, List<List<int>> mentors)
        {
            max = (max < sum) ? sum : max;
            if (students.Count <= 0 && mentors.Count <= 0) return;

            foreach (List<int> student in students)
            {
                foreach (List<int> mentor in mentors)
                {
                    List<List<int>> tempStudents = new List<List<int>>(students);
                    List<List<int>> tempMentors = new List<List<int>>(mentors);
                    tempStudents.Remove(student);
                    tempStudents.Remove(mentor);
                    dfs(ref max, sum+CompatibilityScore(student, mentor), tempStudents, tempMentors);
                }
            }

            return;
        }

        public int MaxCompatibilitySum(List<List<int>> students, List<List<int>> mentors)
        {
            int max = 0;
            foreach (List<int> mentor in mentors)
            {
                List<List<int>> tempMentors = new List<List<int>>(mentors);
                List<List<int>> tempStudents = new List<List<int>>(students);
                tempStudents.Remove(students[0]);
                tempMentors.Remove(mentor);
                dfs(ref max, CompatibilityScore(students[0], mentor), tempStudents, tempMentors);
            }
            return max;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.MaxCompatibilitySum(Globals.students, Globals.mentors));
            return;
        }
    }
}