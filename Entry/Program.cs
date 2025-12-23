// Entry Point
using System;
using _2014;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.LongestSubsequenceRepeated(Globals.s, Globals.k));
        return;
    }
}