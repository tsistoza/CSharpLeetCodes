using System;

namespace DataStruct
{
    public class Node : HeapItem<Node>
    {
        public int? id;
        public int heapIndex;

        public int? val
        {
            get { return id; }
            set { id = value; }
        }
        public int HeapIndex
        {
            get { return heapIndex; }
            set { heapIndex = value; }
        }

        public int CompareTo (Node? other)
        {
            if (this.id > other!.id) return 1;
            if (this.id < other!.id) return -1;
            return 0;
        }
        public Node(int? id=null, int heapIndex=-1)
        {
            this.id = id;
            this.heapIndex = heapIndex;
        }
    }

    public class Heap<T> where T : HeapItem<T>
    {
        public T[] heap;
        int count;
        int maxSizeofHeap;

        public void insert(T item)
        {
            if (count == maxSizeofHeap)
            {
                Console.WriteLine("HEAP IS FULL");
                return;
            }
            item.HeapIndex = count;
            heap[count] = item;
            count++;
            MinHeapify();
            return;
        }

        private void MinHeapify()
        {
            int index = count-1;
            if (index == 0) return;
            // Find index to swap
            while (heap[Parent(index)].val > heap[index].val)
            {
                Swap(Parent(index), index);
                index = Parent(index);
            }
            return;
        }

        public void Swap(int index1, int index2)
        {
            T swapIndex1;
            T swapIndex2;
            swapIndex1 = heap[index1];
            swapIndex2 = heap[index2];

            heap[index1] = swapIndex2;
            heap[index1].HeapIndex = swapIndex2.HeapIndex;

            heap[index2] = swapIndex1;
            heap[index2].HeapIndex = swapIndex1.HeapIndex;
            return;
        }

        public int Parent(int index)
        {
            return (int)((index - 1) / 2);
        }

        public int LeftChild(int index)
        {
            return 2 * index + 1;
        }

        public int RightChild(int index)
        {
            return 2 * index + 2;
        }

        public void readHeap(int index)
        {
            if (index > count - 1) return;
            Console.WriteLine($" {heap[index].val} ");
            readHeap(LeftChild(index));
            readHeap(RightChild(index));
            return;
        }
        public Heap(int maxHeap)
        {
            this.heap = new T[maxHeap];
            this.maxSizeofHeap = maxHeap;
            this.count = 0;
        }
    }

    public interface HeapItem<T> : IComparable<T>
    {
        int? val { get; set; }
        int HeapIndex { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            Heap<Node> heap = new Heap<Node>(7);
            for (int i = 0; i < 7; i++) heap.insert(new Node( 7-i ));
            heap.readHeap(0);
            return;
        }
    }

}