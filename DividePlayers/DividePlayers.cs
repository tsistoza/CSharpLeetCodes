// LeetCode 2491
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] skill = new int[6] { 3, 2, 5, 1, 3, 4 };
    public static int[] skill1 = new int[2] { 3, 4 };
    public static int[] skill2 = new int[4] { 1, 1, 2, 3 };
}

namespace Solution
{
    public class Program
    {
        private List<List<int>> GenerateTeam(int[] skill)
        {
            List<List<int>> teams = new List<List<int>>();
            for (int i = 1; i<skill.Length; i++)
            {
                int targetSkill = skill[0] + skill[i];
                List<int> bucket = skill.ToList();

                int target = targetSkill - bucket[0];
                while (bucket.Contains(target))
                {
                    List<int> team = new List<int>() { bucket[0], target };
                    bucket.RemoveAt(0);
                    bucket.Remove(target);
                    teams.Add(team);
                    if (bucket.Count == 0)
                        break;
                    target = targetSkill - bucket[0];
                }

                if (bucket.Count == 0) break;
                teams.Clear();
            }
            return teams;
        }
        public long DividePlayers(int[] skill)
        {
            if (skill.Length == 2)
                return (long) skill[0] * skill[1];

            long chemistry = 0;
            List<List<int>> teams = GenerateTeam(skill);
            if (teams.Count == 0) return -1;


            for (int i = 0; i < teams.Count; i++)
                chemistry += (teams[i][0] * teams[i][1]);
            return chemistry;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.DividePlayers(Globals.skill));
            Console.WriteLine(obj.DividePlayers(Globals.skill1));
            Console.WriteLine(obj.DividePlayers(Globals.skill2));
            return;
        }
    }
}