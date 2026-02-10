// Entry Point
using System;
using _3719;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.LongestBalanced(Globals.nums));
        return;
    }
}
