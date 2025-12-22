// LeetCode 3484
using System;
using System.Collections.Generic;

namespace _3484
{
    public static class Globals
    {
        public static int rows = 3;
    }

    public class Spreadsheet
    {
        List<int[]> document;
        HashSet<(int,int)> CellsSet = new HashSet<(int,int)> ();

        public Spreadsheet(int rows)
        {
            document = new List<int[]>();
            for (int i=0; i<rows; i++)
                document.Add(new int[26]);
        }

        private ( int, int ) GetPosition(string cell)
        {
            int col = cell[0] - 65;
            string rowStr = cell.Substring(1);
            int row = Convert.ToInt32(rowStr);

            if (row < 0 || row >= document.Count) row = -1;
            if (col < 0 || col > 25) col = -1;
            return (row, col);
        }

        public void SetCell(string cell, int value)
        {
            (int row, int col) = GetPosition(cell);
            document[row][col] = value;
            if (!CellsSet.Contains((row, col)))
                CellsSet.Add((row, col));
        }

        public void ResetCell(string cell)
        {
            (int row, int col) = GetPosition(cell);
            document[row][col] = 0;
        }

        public int GetValue(string formula)
        {
            String newFormula = formula.Substring(1); // Remove =
            string[] operation = newFormula.Split('+'); // X + Y --> XY --> 01
            int num1, num2;

            if (operation[0][0] >= 48 && operation[0][0] <= 57) num1 = Convert.ToInt32(operation[0]);
            else
            {
                (int row, int col) = GetPosition(operation[0]);
                if (!CellsSet.Contains((row, col))) return 0;
                num1 = document[row][col];
            }

            if (operation[1][0] >= 48 && operation[1][0] <= 57) num2 = Convert.ToInt32(operation[1]);
            else
            {
                (int row, int col) = GetPosition(operation[1]);
                if (!CellsSet.Contains((row, col))) return 0;
                num2 = document[row][col];
            }
                return num1 + num2;
        }
    }
}
