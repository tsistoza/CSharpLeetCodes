// LeetCode 352
using System;
using System.Collections.Generic;

namespace _352
{
    public class SummaryRanges
    {
        private SortedDictionary<int, int> heap;
        public List<List<int>> getIntervals()
        {
            List<int> keys = new List<int>(heap.Keys);
            List<List<int>> disjointStream = new List<List<int>>();
            
            while (keys.Count > 0)
            {
                int key = keys.First();
                List<int> disjoint = new List<int>();
                while (heap.ContainsKey(key))
                {
                    disjoint.Add(key);
                    keys.Remove(key);
                    key = heap[key];
                }
                if (disjoint.Count == 1) disjointStream.Add(new List<int> { disjoint[0], disjoint[0] });
                else disjointStream.Add(new List<int> { disjoint.First(), disjoint.Last() });
            }
            return disjointStream;
        }
        public void addNum(int value)
        {
            this.heap.Add(value, value + 1);
            return;
        }
        public SummaryRanges()
        {
            heap = new SortedDictionary<int, int>();
        }
    }
}