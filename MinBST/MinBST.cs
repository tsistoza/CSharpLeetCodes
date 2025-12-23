using System;
using System.Collections.Generic;

namespace Solution
{
    public static class Globals
    {
        public static readonly List<int> list = new List<int>() { 4, 2, 6, 1, 3 };
    }
    public class Node
    {
        public int id;
        public Node? left;
        public Node? right;

        // Constructor 
        public Node (int val=0, Node? left=null, Node? right=null)
        {
            this.id = val;
            this.left = left;
            this.right = right;
        }
    }
    public class BST
    {
        public Node? root;
        List<int> ints;

        // Constructor
        public BST (Node? root = null)
        {
            this.ints = new List<int> ();
            this.root = root;
        }

        public int minDiffInBST()
        {
            int minDiff = ints[0] - ints[1];
            for (int i=0; i<ints.Count-1; i++)
            {
                for (int j=i+1; j<ints.Count-1; j++)
                {
                    if (minDiff > Math.Abs(ints[i] - ints[j])) minDiff = Math.Abs(ints[i] - ints[j]);
                }
            }
            return minDiff;
        }

        public void createBST()
        {
            Node nodePtr;
            Node newNode = new Node(4);
            this.root = newNode;

            newNode = new Node(2);
            this.root.left = newNode;
            newNode = new Node(6);
            this.root.right = newNode;
            nodePtr = this.root.left;

            newNode = new Node(1);
            nodePtr.left = newNode;
            newNode = new Node(3);
            nodePtr.right = newNode;
            return;
        }

        public void insertBST(Node newNode, Node? root)
        {
            if (this.root == null) // Root is not initialized
            {
                this.root = newNode;
                return;
            }
            if (root!.id > newNode.id && root.left == null) //Append to Left/Right is left/right is null
            {
                root.left = newNode;
                return;
            }
            if (root!.id < newNode.id && root.right == null)
            {
                root.right = newNode;
                return;
            }
            if (root!.id > newNode.id && root.left != null) insertBST(newNode, root.left!); // Keep Traversing down BST
            if (root!.id < newNode.id && root.right != null) insertBST(newNode, root.right!);
            return;
        }

        public void printPreorder(Node? root)
        {
            if (root == null) return;
            Console.Write($"{root.id} ");
            this.ints.Add(root.id);
            if (root.left != null) printPreorder(root.left);
            if (root.right != null) printPreorder(root.right);
            return;
        }
    }

    public class Program
    {
        public static void Main()
        {
            BST obj = new BST();
            foreach (int i in Globals.list)
            {
                obj.insertBST(new Node(i), obj.root);
            }
            obj.printPreorder(obj.root);
            Console.WriteLine();
            Console.WriteLine(obj.minDiffInBST());
            return;
        }
    }
}