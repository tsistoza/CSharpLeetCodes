using System;
using System.Collections.Generic;
using Sort;

public static class Globals
{
    public static List<int> unsorted = new List<int>() { 4, 3, 1, 2, 5, 9, 7, 10, 6 };
}

namespace Sort
{
    public class QuickSort
    {
        public void Sort(List<int> list)
        {
            prettyPrint(list);
            List<int> sorted = new List<int>();
            int mid = (int)Math.Round((decimal)(list.Count / 2));
            foreach (int i in Partition(list, mid))
                sorted.Add(i);
            list.Clear();
            list.AddRange(sorted);
            prettyPrint(list);
            return;
        }

        public IEnumerable<int> Partition(List<int> list, int pivot)
        {
            prettyPrint(list);
            if (list.Count == 1)
            {
                yield return list[pivot];
                yield break;
            }
            List<int> lessThanPivot = new List<int>();
            List<int> greaterThanPivot = new List<int>();
            foreach (int i in list)
            {
                if (list[pivot] == i) continue;
                if (list[pivot] > i) lessThanPivot.Add(i);
                else greaterThanPivot.Add(i);
            }

            if (lessThanPivot.Count > 0)
            {
                int midLeft = (int)Math.Round((decimal)(lessThanPivot.Count / 2));
                foreach (int i in Partition(lessThanPivot, midLeft))
                    yield return i;
            }

            yield return list[pivot];

            if (greaterThanPivot.Count > 0)
            {
                int midRight = (int)Math.Round((decimal)(greaterThanPivot.Count / 2));
                foreach (int i in Partition(greaterThanPivot, midRight))
                    yield return i;
            }
            
        }
        
        public void prettyPrint(List<int> sorted)
        {
            Console.Write("{ ");
            foreach (int i in sorted)
                Console.Write($"{i}, ");
            Console.WriteLine("}");
            return;
        }
    }
}

namespace Example
{
    public class Program
    {
        public static void Main()
        {
            QuickSort sort = new QuickSort();
            sort.Sort(Globals.unsorted);
            return;
        }
    }
}