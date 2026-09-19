// LeetCode 3286
using System;
using System.Collections.Generic;

namespace _3286
{
    public static class Globals
    {
        public static int[,] grid = new int[3, 3] {{1, 1, 1}, {1, 0, 1}, {1, 1, 1}};
        public static int health = 5;
    }
    public class Deque<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public int Count { get { return _list.Count; } }
        public bool IsEmpty { get { return _list.Count == 0; } }
        public T Front { get { return _list.First(); } }
        public T Back { get { return _list.Last(); } }

        public void AddFront(T item)
        {
            _list.AddFirst(item);
        }

        public void AddBack(T item)
        {
            _list.AddLast(item);
        }

        public void RemoveFront()
        {
            if (IsEmpty) return;
            _list.RemoveFirst();
        }

        public void RemoveBack()
        {
            if (IsEmpty) return;
            _list.RemoveLast();
        }
    }
    public class Program
    {
        private void FillArray<T>(T[,] array, T value)
        {
            int m = array.GetLength(0);
            int n = array.GetLength(1);

            for (int i=0; i<m; i++)
                for (int j=0; j<n; j++)
                    array[i, j] = value;

            return;
        }
        public bool FindSafeWalk(int[,] grid, int health)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            int[] dirX = { -1, 0, 1, 0 };
            int[] dirY = { 0, -1, 0, 1 };

            int[,] dist = new int[m, n];
            int[,] heart = new int[m, n];
            FillArray<int>(dist, int.MaxValue);
            FillArray<int>(heart, health);
            dist[0, 0] = 0;
            heart[0, 0] = (grid[0, 0] == 1) ? 1 : 0;


            Queue<(int, int, int, int)> queue = new Queue<(int, int, int, int)>();
            queue.Enqueue((0, 0, 0, grid[0, 0]));

            while (queue.Count > 0)
            {
                (int x, int y, int currDist, int currHealth) = queue.Dequeue();

                //Console.WriteLine($"x = {x}, y = {y}, dist={currDist}, heart={currHealth}");

                for (int i=0; i<4; i++)
                {
                    int newX = dirX[i] + x;
                    int newY = dirY[i] + y;
                    if (newX < 0 || newX >= m || newY < 0 || newY >= n) continue;

                    int newDist = currDist + 1;
                    int newHealth = currHealth + grid[newX, newY];

                    //Console.WriteLine($"newHealth = {newHealth}");
                    if (newX == m - 1 && newY == n - 1 && newHealth < health) return true;

                    if (newHealth >= health) continue;

                    // Prioritize Shorter Distance
                    if (newDist < dist[newX, newY])
                    {
                        dist[newX, newY] = newDist;
                        heart[newX, newY] = (newHealth < heart[newX, newY]) ? newHealth : heart[newX, newY];
                        queue.Enqueue((newX, newY, newDist, newHealth));
                        continue;
                    }

                    if (newHealth < heart[newX, newY])
                    {
                        heart[newX, newY] = newHealth;
                        queue.Enqueue((newX, newY, newDist, newHealth));
                        continue;
                    }
                }
            }

            return false;
        }
    }
}
