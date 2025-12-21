// Entry Point
using System;
using _1652;

public class EntryPoint
{
    public static void Main(string[] args)
    {
        Program obj = new Program();
        foreach (int i in obj.Decrypt(Globals.code, Globals.k)) Console.Write($"{i} ");
        Console.WriteLine();
        foreach (int i in obj.Decrypt(Globals.code1, Globals.k1)) Console.Write($"{i} ");
        Console.WriteLine();
        foreach (int i in obj.Decrypt(Globals.code2, Globals.k2)) Console.Write($"{i} ");
        Console.WriteLine();
        return;
    }
}