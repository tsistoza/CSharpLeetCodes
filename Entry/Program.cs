// Entry Point
using System;
using _3355;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.isZeroArray(Globals.nums, Globals.queries));
        return;
    }
}