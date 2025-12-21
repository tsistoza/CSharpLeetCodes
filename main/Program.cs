// Entry Point
using System;
using _955;

public class EntryPoint
{
    public static void Main()
    {
        Program program = new Program();
        Console.WriteLine(program.MinDeletionSize(Globals.strs));
        return;
    }
}