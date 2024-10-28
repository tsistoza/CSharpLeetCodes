using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace Solution
{
    public class Program
    {
        public int[,] squares = new int[3, 3] { {1, 0, 1},
                                                {1, 1, 0},
                                                {1, 1, 0} };
        public int CountSquares(int[,] squares)
        {
            List<KeyValuePair<int,int>> list = new List<KeyValuePair<int,int>>(); // Contains the indexes for a square
            int sum = 0;
            int sizeOfSquare;
            int rows = squares.GetLength(0);
            int cols = squares.GetLength(1);
            if (rows > cols) sizeOfSquare = cols;
            else sizeOfSquare = rows;

            while (sizeOfSquare > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        AddToList(list, sizeOfSquare, i, j);
                        if (isSquare(list, sizeOfSquare)) sum++;
                        list.Clear();
                    }
                }
                sizeOfSquare--;
            }
            return sum;
        }

        // Gets all the indexes that make a square with length sizeOfSquare and adds to the list
        // Note that the anchor is the top left of the square [i,j]
        private void AddToList(List<KeyValuePair<int,int>> list, int sizeOfSquare, int i, int j)
        {
            for(int i2=i; i2<=i+sizeOfSquare-1; i2++)
            {
                if (i2 > this.squares.GetLength(0)-1) break;
                for(int j2=j; j2<=j+sizeOfSquare-1; j2++)
                {
                    if (j2 > this.squares.GetLength(1)-1) break;
                    KeyValuePair<int, int> kvp = new KeyValuePair<int, int>(i2,j2);
                    list.Add(kvp);
                }
            }
            if (list.Count != sizeOfSquare * sizeOfSquare) list.Clear();
            return;
        }

        // Checks if the list of indexes for a square is a square of ones
        public bool isSquare(List<KeyValuePair<int,int>> list, int sizeOfSquare)
        {
            if (list.Count != sizeOfSquare*sizeOfSquare) return false;
            foreach (KeyValuePair<int,int> i in list) if (squares[i.Key, i.Value] != 1) return false;
            return true;
        }

        public static void Main()
        {
            Program obj = new Program();
            Console.WriteLine(obj.CountSquares(obj.squares));
            return;
        }
    }
}