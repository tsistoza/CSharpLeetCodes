// LeetCode 190
using System;
using System.Collections.Generic;

namespace _190
{
    public static class Globals
    {
        public static uint n = 0b00000010100101000001111010011100;
    }
    public class Program
    {
        public List<uint> toString(uint n)
        {
            List<uint> binary = new List<uint>();
            for (int i=0; i<32; i++)
                binary.Add(((n >> i) & 1));
            return binary;
        }
        public uint toInteger(List<uint> binary)
        {
            uint ans = 0;
            uint multiplicand = 1;
            for (int i=0; i<binary.Count; i++)
            {
                ans += (uint)binary[i] * multiplicand;
                multiplicand *= 2;
            }
            return ans;
        }
        public uint reverseBits(uint n)
        {
            List<uint> binary = toString(n);
            binary.Reverse();
            return toInteger(binary);
        }
    }
}
