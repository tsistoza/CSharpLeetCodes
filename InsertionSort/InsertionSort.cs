using System;
using System.Collections.Generic;

namespace Solution
{
    public static class Globals
    {
        public static readonly List<int> nums = new List<int>() { 4, 2, 1, 3 };
    }

    public class Program
    {
        public LinkedList<int> list = new LinkedList<int>();

        public void readLinkedList()
        {
            Console.Write("Linked List: ");
            foreach(int i in this.list)
            {
                Console.Write($"{i} -> ");
            }
            Console.Write("NULL\n");
            return;
        }
        public void InsertNode(int value)
        {
            // List has no nodes
            if (this.list.Count == 0)
            {
                this.list.AddLast(value);
                return;
            }

            // Sort Nodes based on values
            IEnumerator<int> enumerator = this.list.GetEnumerator();
            while(enumerator.MoveNext())
            {
                if (value < enumerator.Current)
                {
                    LinkedListNode<int> node = this.list.Find(enumerator.Current)!;
                    this.list.AddBefore(node, value);
                    return;
                }
            }

            // If it did not return, then there is no value in 'this.list' that is < given passed value, so we just append value to end of list.
            this.list.AddLast(value);
            return;
        }

        public static int Main()
        {
            Program obj = new Program();
            foreach (int i in Globals.nums) obj.InsertNode(i);
            obj.readLinkedList();
            obj.list.Clear();
            foreach (int i in Globals.nums2) obj.InsertNode(i);
            obj.readLinkedList();
            obj.list.Clear();
            return 0;
        }
    }
}