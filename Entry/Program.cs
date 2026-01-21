// Entry Point
using System;
using _3315;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        Program.PrettyPrint(obj.MinBitwiseArray(Globals.nums));
        return;
    }
}
