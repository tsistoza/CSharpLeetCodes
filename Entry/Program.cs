// Entry Point
using System;
using KnapSackProblem;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.MaxValue(Globals.val, Globals.wt, Globals.capacity));
        return;
    }
}
