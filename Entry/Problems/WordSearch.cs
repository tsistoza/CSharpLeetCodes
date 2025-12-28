// LeetCode 79
using System;
using System.Collections.Generic;

namespace _79
{
    public static class Globals
    {
        public static char[][] board =
        {
            new char[4] { 'A', 'B', 'C', 'E' },
            new char[4] { 'S', 'F', 'C', 'S' },
            new char[4] { 'A', 'D', 'E', 'E' }
        };
        public static string word = "ABCCED";
    }
    public class Program
    {
        private void dfs(int i, int j, int index, ref int maxIndex, ref HashSet<(int,int)> vis, char[][] board, string word)
        {
            if (maxIndex == word.Length) return;
            if (index == word.Length)
            {
                maxIndex = index;
                return;
            }
            vis.Add((i, j));

            int[] dirX = { -1, 0, 1, 0 };
            int[] dirY = { 0, -1, 0, 1 };
            for (int dir=0; dir<4; dir++)
            {
                int newX = i + dirX[dir];
                int newY = j + dirY[dir];

                if (newX < 0 || newY < 0 || newX >= board.Length || newY >= board[0].Length) continue;

                if (vis.Contains((newX, newY))) continue;
                
                if (board[newX][newY] != word[index]) continue;
                dfs(newX, newY, index+1, ref maxIndex, ref vis, board, word);
            }
            return;
        }
        public bool Exist(char[][] board, string word)
        {
            // Find all word[0], to make DFS easier
            List<(int,int)> indexes = new List<(int,int)> ();
            for (int i=0; i<board.Length; i++)
                for (int j=0; j<board[i].Length; j++)
                    if (board[i][j] == word[0]) indexes.Add((i, j));


            int maxIndex = 0;
            HashSet<(int,int)> vis = new HashSet<(int,int)> ();
            foreach ((int, int) index in indexes) // for each board[i][j] == word[0], do dfs
            {
                dfs(index.Item1, index.Item2, 1, ref maxIndex, ref vis, board, word);
                if (maxIndex == word.Length) break;
            }
            return (maxIndex == word.Length);
        }
    }
}
