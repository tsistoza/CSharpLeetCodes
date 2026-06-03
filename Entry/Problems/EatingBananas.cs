// LeetCode 875
using System;
using System.Collections.Generic;

namespace _875
{
    public static class Globals
    {
        public static int[] piles = { 30, 11, 23, 4, 20 };
        public static int h = 6;
    }

    public class Program
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            Array.Sort(piles);
            int low = 1, high = piles[piles.Length - 1];

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                //Console.WriteLine($"low = {low}, high = {high}, mid = {mid}");
                int currTime = CalculateTime(piles, h, mid);
                //Console.WriteLine($"CurrTime = {currTime}");

                if (currTime < h)
                {
                    high = mid - 1;
                    continue;
                }

                if (currTime > h)
                {
                    low = mid + 1;
                    continue;
                }

                low = mid;
                high = mid;
            }

            int temp = low;
            while (h == CalculateTime(piles, h, temp))
            {
                low = temp;
                temp--;
            }
            return low;
        }

        private int CalculateTime(int[] piles, int h, int k)
        {
            int time = 0;
            for (int i=0; i<piles.Length; i++)
            {
                if (piles[i] <= k) time++;
                else if (piles[i] % k == 0) time += (piles[i] / k);
                else time += (piles[i] / k) + 1;
            }

            return time;
        }
    }
}
