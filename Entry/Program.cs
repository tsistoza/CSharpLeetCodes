// Entry Point
using System;
using _516;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.LongestPalindromeSubseq(Globals.s));
        return;
    }
}
