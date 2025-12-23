// Entry Point
using System;
using _474;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.FindMaxForm(Globals.strs, Globals.m, Globals.n));
        return;
    }
}