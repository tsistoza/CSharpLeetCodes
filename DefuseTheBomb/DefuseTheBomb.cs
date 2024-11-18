// LeetCode 1652
using System;
using System.Collections;
using System.Collections.Generic;

public static class Globals
{
    public static readonly List<int> code = new List<int>() { 5, 7, 1, 4 };
    public static readonly int k = 3;
    public static readonly List<int> code1 = new List<int>() { 1, 2, 3, 4 };
    public static readonly int k1 = 0;
    public static readonly List<int> code2 = new List<int>() { 2, 4, 9, 3 };
    public static readonly int k2 = -2;
}

namespace Solution
{
    public class Node
    {
        public Node? prev;
        public Node? next;
        public int id;

        public Node(int id, Node? prev=null, Node? next=null)
        {
            this.id = id; this.prev = prev; this.next = next;
        }
    }
    public class CircularLinkedList
    {
        private Node currentNode;
        private Node head;
        private Node tail;

        public void InsertNode(Node node)
        {
            if (this.head == this.tail)
            {
                this.tail = node;
                this.tail.prev = head;
                this.tail.next = head;
                this.head.next = tail;
                this.head.prev = tail;
                return;
            }
            Node oldTailNode = tail;
            this.tail.next = node;
            this.tail = node;
            this.tail.prev = oldTailNode;
            this.tail.next = head;
            this.head.prev = this.tail;
        }

        public void Advance(int k)
        {
            if (k < 0) this.currentNode = this.currentNode.prev!;
            if (k > 0) this.currentNode = this.currentNode.next!;
            return;
        }

        public int Decrypt(int k, int val)
        {
            MoveCurrentNode(val);
            int track = k;
            int sum = 0;
            while (track != 0)
            {
                Advance(track);
                sum += this.currentNode.id;
                if (track > 0) track--;
                if (track < 0) track++;
            }
            return sum;
        }

        public void MoveCurrentNode(int val)
        {
            while (this.currentNode.id != val)
                this.currentNode = this.currentNode.next!;
            return;
        }

        public void Reset()
        {
            this.currentNode = this.head;
            return;
        }

        public CircularLinkedList (Node head)
        {
            this.currentNode = head;
            this.head = head;
            this.tail = head;
        }
    }

    public class Program
    {
        public IEnumerable<int> Decrypt(List<int> code, int k)
        {
            Node head = new Node(code[0]);
            CircularLinkedList list = new CircularLinkedList(head);
            for(int i=1; i<code.Count; i++) list.InsertNode(new Node(code[i]));

            List<int> decryptedCode = new List<int>();
            foreach (int i in code) decryptedCode.Add(list.Decrypt(k, i));
            return decryptedCode;
        }
        public static void Main(string[] args)
        {
            Program obj = new Program();
            foreach (int i in obj.Decrypt(Globals.code, Globals.k)) Console.Write($"{i} ");
            Console.WriteLine();
            foreach (int i in obj.Decrypt(Globals.code1, Globals.k1)) Console.Write($"{i} ");
            Console.WriteLine();
            foreach (int i in obj.Decrypt(Globals.code2, Globals.k2)) Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}