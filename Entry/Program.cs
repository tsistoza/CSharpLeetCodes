// Entry Point
using System;
using _1266;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.MinTimeToVisitAllPoints(Globals.points));
        return;
    }
}