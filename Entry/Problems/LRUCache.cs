// LeetCode 146
using System;
using System.Collections.Generic;

namespace _146
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
}