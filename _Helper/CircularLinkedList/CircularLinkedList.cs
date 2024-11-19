using System;
using System.Collections;
using System.Collections.Generic;
public static class Globals
{
    public static readonly List<int> code = new List<int>() { 5, 7, 1, 4 };
    public static readonly List<int> code1 = new List<int>() { 1, 2, 3, 4 };
}

namespace Solution
{
    public class Node : IListItem<Node>
    {

        private Node? prev;
        private Node? next;
        public int id;

        public Node? Prev
        {
            get { return prev; }
            set { prev = value; }
        }
        public Node? Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node(int id, Node? prev = null, Node? next = null)
        {
            this.prev = prev;
            this.next = next;
            this.id = id;
        }
    }

    public interface IListItem<T>
    {
        T? Prev { get; set; }
        T? Next { get; set; }
    }

    public class CircularLinkedList<T> : IEnumerable<T> where T : IListItem<T>
    {
        public T head;
        public T tail;
        public int Count;

        public void InsertNodeT(T node)
        {
            // Insert New Node
            this.tail.Next = node;
            node.Prev = this.tail;
            this.tail = this.tail.Next;
            node.Next = this.head;

            // Reset Tail and Head
            tail = node;
            head.Prev = tail;
            Count++;
        }

        public CircularLinkedList(T item)
        {
            head = item;
            tail = item;
            Count = 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnum(head!, tail!);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnum(head!, tail!);
        }

        class ListEnum : IEnumerator<T>
        {
            public T currentNode;
            public T head;
            public T tail;

            T IEnumerator<T>.Current
            {
                get { return currentNode; }
            }

            public object Current
            {
                get { return currentNode; }
            }

            public bool MoveNext()
            {
                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                currentNode = this.head;
            }

            public void Dispose() { }
            public ListEnum(T head, T tail)
            {
                this.head = head;
                this.tail = tail;
                this.currentNode = head;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Node head = new Node(Globals.code[0]);
            CircularLinkedList<Node> list = new CircularLinkedList<Node>(head);
            for (int i = 1; i < Globals.code.Count; i++)
                list.InsertNodeT(new Node(Globals.code[i]));
            IEnumerator<Node> enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.Write($"{enumerator.Current.id} ");
            }
            return;
        }
    }
}