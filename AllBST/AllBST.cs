using System;
using System.Collections.Generic;


public static class Global
{
    public static List<int> list1 = new List<int>() { 1, 2, 4 };
    public static List<int> list2 = new List<int>() { 0, 1, 3 };
}


namespace Solution {

    public class Node{
        public int id;

        public Node(int val) { this.id = val; }
    }

    public class NodeComp : IComparer<Node> {
        public int Compare (Node x, Node y) {
            return x.id.CompareTo (y.id);
        }
    }

    public class Set
    {
        public SortedSet<Node> set;
        public SortedSet<Node> set2;
        public SortedSet<Node> combinedSet;

        public void createBST()
        {
            this.set = new SortedSet<Node>(new NodeComp());
            foreach (int x in Global.list1) this.set.Add(new Node(x));

            this.set2 = new SortedSet<Node>(new NodeComp());
            foreach (int x in Global.list2) this.set2.Add(new Node(x));
            return;
        }

        public void readBST(SortedSet<Node> set)
        {
            Console.Write("BST: ");
            foreach (Node x in set)
            {
                Console.Write(x.id);
                Console.Write(" -> ");
            }
            Console.Write("\n");
            return;
        }
        
        public void CombineSet()
        {
            this.combinedSet = new SortedSet<Node>(new NodeComp());
            foreach (Node x in this.set)
            {
                foreach (Node y in this.set2)
                {
                    this.combinedSet.Add(x);
                    this.combinedSet.Add(y);
                }
            }
            return;
        }

        public static void Main()
        {
            Set bst = new Set();
            SortedSet<Node> set;
            bst.createBST();
            set = bst.set;
            bst.readBST(set);
            set = bst.set2;
            bst.readBST(set);
            bst.CombineSet();
            set = bst.combinedSet;
            bst.readBST(set);
            return;
        }
    }
}

