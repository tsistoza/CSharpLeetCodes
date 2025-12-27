// LeetCode 2115
using System;
using System.Collections.Generic;

namespace _2115
{
    public static class Globals
    {
        public static string[] recipes = { "bread", "sandwich", "burger" };
        public static List<List<string>> ingredients = new List<List<string>>()
        {
            new List<string>() { "yeast", "flour" },
            new List<string>() { "bread", "meat" },
            new List<string>() { "sandwich", "meat", "bread" }
        };
        public static string[] supplies = { "yeast", "flour", "meat" };
    }
    public class Program
    {
        public static void prettyPrint(List<string> list)
        {
            Console.Write("{ ");
            foreach (string item in list)
                Console.Write($"{item}, ");
            Console.WriteLine("} ");
        }
        public List<string> FindAllRecipes(string[] recipes, List<List<string>> ingredients, string[] supplies)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < recipes.Length; i++)
            {
                // Check if we have ingredients
                int j = 0;
                for (; j < ingredients[i].Count;)
                {
                    // Check if ingredient is a recipe thats been made
                    if (result.Contains(ingredients[i][j]))
                    {
                        j++;
                        continue;
                    }

                    // If not check if we can make using the supplies
                    if (Array.FindIndex(supplies, supply => supply == ingredients[i][j]) == -1)
                        break;
                    j++;
                }

                if (j == ingredients[i].Count) result.Add(recipes[i]);
            }

            return result;
        }
    }
}
