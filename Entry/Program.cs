// Entry Point
using System;
using _1170;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        obj.NumSmallerByFrequency(Globals.queries, Globals.words);
        return;
    }
}
