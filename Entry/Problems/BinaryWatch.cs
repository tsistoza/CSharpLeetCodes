using System;
using System.Collections.Generic;
using System.Text;

namespace _401
{
    public static class Globals
    {
        public static int turnedOn = 1;
    }
    public class Program
    {
        private int CountSetBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n &= (n - 1);
                count++;
            }

            return count;
        }
        private static void PrettyPrint(IList<string> list)
        {
            Console.Write("{ ");
            foreach (string s in list)
                Console.Write($"{s}, ");
            Console.WriteLine("}\n");
            return;
        }
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            List<string> result = new List<string>();
            for (int hour=0; hour<12; hour++)
            {
                for (int minute=0; minute<60; minute++)
                {
                    int numBits = CountSetBits(hour);
                    numBits += CountSetBits(minute);
                    string time = hour + ":";
                    time += (minute < 10) ? "0" + minute : minute;
                    if (numBits == turnedOn) result.Add(time);
                }
            }
            PrettyPrint(result);
            return result;
        }
    }
}
