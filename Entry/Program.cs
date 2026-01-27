// Entry Point
using System;
using _3650;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.MinCost(Globals.n, Globals.edges));
        return;
    }
}
