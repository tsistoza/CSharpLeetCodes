// Entry Point
using System;
using _1415;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.GetHappyString(Globals.n, Globals.k));
        return;
    }
}