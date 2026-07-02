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
        private readonly LinkedList<T> _list = new LinkedList<T>();

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
            heart[0, 0] = 0;

            Deque<List<int>> dq = new Deque<List<int>>();
            dq.AddBack(new List<int> { 0, 0 });

            while (!dq.IsEmpty)
            {
                List<int> front = dq.Front;
                dq.RemoveFront();
                int x = front[0], y = front[1];

                //Console.WriteLine($"x = {x}, y = {y}, dist={dist[x, y]}, heart={heart[x, y]}");

                for (int i=0; i<4; i++)
                {
                    int newX = dirX[i] + front[0];
                    int newY = dirY[i] + front[1];
                    if (newX < 0 || newX >= m || newY < 0 || newY >= n) continue;

                    int newDist = dist[x, y] + 1;
                    int newHealth = heart[x, y] + grid[x, y];

                    if (newX == m - 1 && newY == n - 1 && newHealth < health) return true;

                    // Prioritize health first
                    if (newHealth < heart[newX, newY])
                    {
                        dist[newX, newY] = newDist;
                        heart[newX, newY] = newHealth;
                        if (grid[x, y] == 1)
                            dq.AddBack(new List<int> { newX, newY });
                        else 
                            dq.AddFront(new List<int> { newX, newY });
                        continue;
                    }

                    if (newHealth > heart[newX, newY])
                    {
                        continue;
                    }

                    // Health is the same
                    if (newDist < dist[newX, newY])
                    {
                        dist[newX, newY] = newDist;
                        dq.AddBack(new List<int> { newX, newY });
                    }
                }
            }
            
            return (heart[m-1, n-1] < health);
        }
    }
}
