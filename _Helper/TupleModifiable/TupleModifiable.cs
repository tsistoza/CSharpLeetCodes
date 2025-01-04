using System;
using System.Collections.Generic;

namespace Helpers
{
    public class Pair<T1, T2>
    {
        public T1? item1 { get; set; }
        public T2? item2 { get; set; }

        public Pair()
        {
            item1 = default;
            item2 = default;
        }

        public Pair(T1 _item1, T2 _item2)
        {
            item1 = _item1;
            item2 = _item2;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Pair<int, int> pair = new Pair<int, int>(1, 2);
            Console.WriteLine(pair.item1);
            Console.WriteLine(pair.item2);
            return;
        }
    }
}

