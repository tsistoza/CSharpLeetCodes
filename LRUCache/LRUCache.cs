// LeetCode 146
using System;
using System.Collections.Generic;

namespace Solution
{
    public class LRUCache
    {
        private List<int> cache;
        private Dictionary<int, int> kvp;

        public int Get(int key)
        {
            if (kvp.ContainsKey(key))
            {
                cache.Remove(key);
                cache.Add(key);
                return kvp[key];
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (kvp.ContainsKey(key))
            {
                if (kvp.ContainsKey(key)) kvp[key] = value;
                return;
            }

            // Remove Key in first (LRU KEY)
            if (cache.Count == cache.Capacity)
            {
                kvp.Remove(cache[0]);
                cache.RemoveAt(0);
            }

            // Add Key to the back of the list
            cache.Add(key);
            this.kvp.Add(key, value);
            return;
        }

        public LRUCache(int capacity)
        {
            cache = new List<int>(capacity);
            kvp = new Dictionary<int, int>();
        }
    }
    public class Program
    {
        public static void Main()
        {
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            Console.WriteLine(lRUCache.Get(1));    // return 1
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            Console.WriteLine(lRUCache.Get(2));    // returns -1 (not found)
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            Console.WriteLine(lRUCache.Get(1));    // return -1 (not found)
            Console.WriteLine(lRUCache.Get(3));    // return 3
            Console.WriteLine(lRUCache.Get(4));    // return 4
            return;
        }
    }
}