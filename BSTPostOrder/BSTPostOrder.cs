// LeetCode 145
using System;
using System.Collections;

namespace Solution
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left=null, TreeNode? right=null)
        {
            this.val = val; this.left = left; this.right = right;
        }
    }

    public class BST
    {
        public TreeNode? root;

        public IEnumerable<int> postOrderTraversal(TreeNode root)
        {
            if (root.left != null)
            {
                foreach (int i in postOrderTraversal(root.left!)) yield return i;
            }
            if (root.right != null)
            {
                foreach (int i in postOrderTraversal(root.right!)) yield return i;
            }
            yield return root.val;
        }

        public void createTestCase()
        {
            TreeNode nodePtr;
            TreeNode root = new TreeNode(1);
            this.root = root;
            TreeNode newNode = new TreeNode(2);
            this.root.right = newNode;
            nodePtr = this.root.right;
            newNode = new TreeNode(3);
            nodePtr.left = newNode;
            return;
        }

        public void createTestCase2()
        {
            TreeNode nodePtr;
            TreeNode root = new TreeNode(1);
            this.root = root;
            
            // Left Side of the Tree
            TreeNode newNode = new TreeNode(2);
            this.root.left = newNode;
            nodePtr = this.root.left;
            newNode = new TreeNode(4);
            nodePtr.left = newNode;
            newNode = new TreeNode(5);
            nodePtr.right = newNode;
            nodePtr = nodePtr.right;
            newNode = new TreeNode(6);
            nodePtr.left = newNode;
            newNode = new TreeNode(7);
            nodePtr.right = newNode;

            // Right Side of the Tree
            newNode = new TreeNode(3);
            this.root.right = newNode;
            nodePtr = this.root.right;
            newNode = new TreeNode(8);
            nodePtr.right = newNode;
            newNode = new TreeNode(9);
            nodePtr = nodePtr.right;
            nodePtr.left = newNode;
        }
        public BST()
        {
            this.root = null;
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Test Case 1
            BST bst1 = new BST();
            bst1.createTestCase();
            foreach (int i in bst1.postOrderTraversal(bst1.root!))
                Console.Write($"{i} ");
            Console.WriteLine();

            // Test Case 2
            BST bst2 = new BST();
            bst2.createTestCase2();
            foreach (int i in bst1.postOrderTraversal(bst2.root!))
                Console.Write($"{i} ");
            Console.WriteLine();
            return;
        }
    }
}