// Entry Point
using System;
using _904;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Console.WriteLine(obj.TotalFruit(Globals.fruits));
        return;
    }
}