using System;
using System.Collections.Generic;

/* LeetCode 1545
 * Given two positive integers n and k, the binary string Sn is formed as follows:

    S1 = "0"
    Si = Si - 1 + "1" + reverse(invert(Si - 1)) for i > 1

Where + denotes the concatenation operation, reverse(x) returns the reversed string x, and invert(x) inverts all the bits in x (0 changes to 1 and 1 changes to 0).

For example, the first four strings in the above sequence are:

    S1 = "0"
    S2 = "011"
    S3 = "0111001"
    S4 = "011100110110001"

Return the kth bit in Sn. It is guaranteed that k is valid for the given n.
 */

public static class Globals
{
    public static readonly int n = 3;
    public static readonly int k = 1;
}

namespace Solution
{
    public class Program
    {
        public string binaryString = "";

        public void createBinaryString(int n)
        {
            this.binaryString = this.binaryString + "0";
            for (int i=1; i<n; i++)
            {
                string s = this.binaryString + "1" + reverseBits(invertBits());
                this.binaryString = s;
            }
            return;
        }
        public string invertBits()
        {
            char[] charArray = this.binaryString.ToArray();
            for (int i = 0; i < this.binaryString.Length; i++)
            {
                if (charArray[i] == '0') charArray[i] = '1';
                else charArray[i] = '0';
            }
            return new string(charArray);
        }
        public string reverseBits(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public char FindKthBit(int n, int k)
        {
            createBinaryString(n);
            return this.binaryString[k-1];
        }
        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.FindKthBit(Globals.n, Globals.k));
            return;
        }
    }
}