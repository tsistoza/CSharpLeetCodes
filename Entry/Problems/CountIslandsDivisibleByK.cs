using System;
using System.Collections.Generic;
using System.Text;

namespace _3619
{
    public static class Globals
    {
        public static int[][] grid = new int[5][]
        {
            new int[5] { 0, 2, 1, 0, 0 },
            new int[5] { 0, 5, 0, 0, 5 },
            new int[5] { 0, 0, 1, 0, 0 },
            new int[5] { 0, 1, 4, 7, 0 },
            new int[5] { 0, 2, 0, 0, 8 }
        };
        public static int k = 5;
    }
    public class Deque
    {
        private (int, int)[] buffer;
        private int tail;
        private int head;
        private int size;
        private int capacity;

        public bool IsEmpty => (size == 0);

        // Both Head & Tail will point towards an empty index which needs to be filled, when operating AddFront(), AddBack()
        public Deque(int _capacity)
        {
            capacity = _capacity;
            tail = 0;
            head = 0;
            size = 0;
            buffer = new (int, int)[capacity];
        }

        public void AddFront((int, int) item)
        {
            if (size == capacity) throw new ArgumentOutOfRangeException("Head == Tail increase the size of buffer");
            head = (head - 1 + capacity) % capacity;
            buffer[head] = item;
            size++;
        }

        public void AddBack((int, int) item)
        {
            if (size == capacity) throw new ArgumentOutOfRangeException("Tail == Head increase the size of buffer");
            buffer[tail] = item;
            tail = (tail + 1) % capacity;
            size++;
        }

        public (int, int) RemoveFront()
        {
            if (size == 0) throw new ArgumentOutOfRangeException("Deque IS EMPTY");
            (int, int) item = buffer[head];
            head = (head + 1) % capacity;
            size--;
            return item;
        }

        public (int, int) RemoveBack()
        {
            if (size == 0) throw new ArgumentOutOfRangeException("Deque IS EMPTY");
            tail = (tail - 1 + capacity) % capacity;
            (int, int) item = buffer[tail];
            size--;
            return item;
        }
    }
    public class Program
    {
        private int dfs(bool[,] vis, int[][] grid, Deque bfsQ, int x, int y, int k)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length) return 0;
            if (vis[x, y]) return 0;
            if (grid[x][y] == 0)
            {
                vis[x, y] = true;
                bfsQ.AddFront((x, y));
                return 0;
            }
            vis[x, y] = true;
            int val = grid[x][y];
            val = ((val + dfs(vis, grid, bfsQ, x + 1, y, k)) % k);
            val = ((val + dfs(vis, grid, bfsQ, x - 1, y, k)) % k);
            val = ((val + dfs(vis, grid, bfsQ, x, y + 1, k)) % k);
            val = ((val + dfs(vis, grid, bfsQ, x, y - 1, k)) % k);
            return val;
        }
        public int CountIslands(int[][] grid, int k)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] vis = new bool[m, n];

            int num = 0;
            int[] dirX = { 1, 0 };
            int[] dirY = { 0, 1 };
            Deque bfsQ = new Deque(m * n);
            bfsQ.AddFront((0, 0));
            while (!bfsQ.IsEmpty)
            {
                (int x, int y) = bfsQ.RemoveFront();
                Console.WriteLine($"x = {x}, y = {y}");

                if (!vis[x, y])
                {
                    if (grid[x][y] > 0)
                    {
                        int sum = dfs(vis, grid, bfsQ, x, y, k);
                        num = (sum % k == 0) ? num + 1 : num;
                    }
                    else vis[x, y] = true;
                }

                for (int i=0; i<2; i++)
                {
                    int newX = x + dirX[i];
                    int newY = y + dirY[i];
                    if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
                    if (!vis[newX, newY]) bfsQ.AddFront((newX, newY));
                }
            }

            return num;
        }
    }
}
