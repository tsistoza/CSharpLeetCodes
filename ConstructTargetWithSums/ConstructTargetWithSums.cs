// LeetCode 1354
using System;
using System.Linq;
using System.Collections.Generic;

public static class Globals
{
    public static int[] target = { 9, 3, 5 };
    public static int[] target1 = { 1, 1, 1, 2 };
    public static int[] target2 = { 8, 5 };
}

namespace Solution
{
    public class Program
    {
        public int sum(int[] nums)
        {
            int sum = 0;
            for (int i=0; i<nums.Length; i++)
                sum += nums[i];
            return sum;
        }

        public bool IsPossible(int[] target)
        {
            if (target.Length == 1)
                return (target[0] == 1);

            int sumTarget = sum(target);
            while (target.Max() != 1)
            {
                int curr = target.Max();
                if (sumTarget - curr == 1) return true;

                int x = Array.IndexOf(target, curr);
                int replace = curr % (sumTarget - curr);
                sumTarget = sumTarget - curr + replace;
                if (replace == 0 || replace == target.Max()) return false;
                else target[x] = replace;
            }

            foreach (int x in target) 
                if (x != 1) return false;
            return true;
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.IsPossible(Globals.target));
            Console.WriteLine(obj.IsPossible(Globals.target1));
            Console.WriteLine(obj.IsPossible(Globals.target2));
            return;
        }
    }
}