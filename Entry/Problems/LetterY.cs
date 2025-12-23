// LeetCode 3071
using System;
using System.Collections.Generic;

namespace _3071
{
    public static class Globals
    {
        public static int[,] grid = new int[3, 3]
        {
            { 1, 2, 2 }, { 1, 1, 0 }, { 0, 1, 0 }
        };
    }
    public class Compare : IComparer<List<int>>
    {
        int IComparer< List<int> >.Compare(List<int>? x, List<int>? y)
        {
            if (x == null) return 1;
            if (y == null) return -1;
            if (x[1] < y[1]) return 1;
            if (x[1] > y[1]) return -1;
            return 0;
        }
    }

    public class Program
    {
        public void getAllY(List<Tuple<int,int>> listY, int[,] grid, Tuple<int,int> index)
        {
            int row = index.Item1 + 1;
            int col = index.Item2 + 1;
            for (int i=index.Item1-1; i>=0; i--)
            {
                // Top Right
                listY.Add(new Tuple<int,int>(i, col++));
                // Top Left
                listY.Add(new Tuple<int, int>(i, i));
                // Vertical
                listY.Add(new Tuple<int,int> (row++, index.Item2));
            }
            return;
        }
        
        public int MinimumOperationToWriteY(int[,] grid)
        {
            int operations = 0;
            int x = (int) Math.Floor((decimal)(grid.GetLength(0)/2));
            List<Tuple<int, int>> listY = new List<Tuple<int, int>>();
            Tuple<int, int> center = new Tuple<int, int>(x, x);
            listY.Add(center);
            getAllY(listY, grid, center);

            List<List<int>> inY = new List<List<int>>()
            {
                new List<int>{ 0, 0 }, new List<int> { 1, 0 }, new List<int> { 2, 0 }
            };
            List<List<int>> notInY = new List<List<int>>()
            {
                new List<int>{ 0, 0 }, new List<int> { 1, 0 }, new List<int> { 2, 0 }
            };
           
            for (int i=0; i<grid.GetLength(0); i++)
            {
                for (int j=0; j<grid.GetLength(1); j++)
                {

                    if (listY.Contains(new Tuple<int,int>(i,j)))
                    {
                        inY[grid[i, j]][1]++;
                        continue;
                    }
                    notInY[grid[i, j]][1]++;
                }
            }

            Compare cmp = new Compare();
            inY.Sort(cmp);
            notInY.Sort(cmp);

            IEnumerator<List<int>> yEnumerator = inY.GetEnumerator();
            IEnumerator<List<int>> notYEnumerator = notInY.GetEnumerator();
            yEnumerator.MoveNext(); notYEnumerator.MoveNext();

            if (yEnumerator.Current[0] == notYEnumerator.Current[0])
            {
                if (yEnumerator.Current[1] < notYEnumerator.Current[1]) yEnumerator.MoveNext();
                else notYEnumerator.MoveNext();
            }

            operations += (listY.Count - yEnumerator.Current[1]);
            operations += (grid.Length - listY.Count) - notYEnumerator.Current[1];
            return operations;
        }
    }
}