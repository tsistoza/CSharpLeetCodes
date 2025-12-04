// LeetCode 2211
using System;
using System.Collections.Generic;

public static class Globals
{
    public static string directions = "RLRSLL";
}

namespace Solution
{
    public class Program
    {
        public int CountCollisions(string directions)
        {
            Stack<char> collisions = new Stack<char>();
            collisions.Push(directions[0]);
            int numCollisions = 0;

            for (int i=1; i<directions.Length; i++)
            {
                char top = collisions.Peek();
                char curr = directions[i];

                int currCollision = 0;
                if (top == 'R' && curr == 'L')
                {
                    currCollision = 2;
                    collisions.Pop();
                }
                else if (top == 'S' && curr == 'L') currCollision = 1;
                else if (top == 'R' && curr == 'S')
                {
                    collisions.Pop();
                    collisions.Push('S');
                    currCollision = 1;
                }


                if (currCollision == 0)
                {
                    collisions.Push(curr);
                    continue;
                }
                for (int j = 0; j < currCollision; j++) collisions.Push('S');
                numCollisions += currCollision;
            }
            return numCollisions;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CountCollisions(Globals.directions));
            return;
        }
    }
}