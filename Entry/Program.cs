// Entry Point
using System;
using _514;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.FindRotateSteps(Globals.ring, Globals.key));
        return;
    }
}
