using System;
using System.Collections.Generic;

namespace Sort
{
    public class SortBase
    {
        public virtual void Sort(List<int> unsorted)
        {
            return;
        }

        public void prettyPrint(List<int> sorted)
        {
            Console.Write("{ ");
            foreach (int i in sorted)
                Console.Write($"{i}, ");
            Console.WriteLine();
            return;
        }
    }
}