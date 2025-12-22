// LeetCode 337
using System;
using System.Collections.Generic;

namespace _337
{
    public static class Globals
    {
        public static List<int> nodes = new List<int>() { 3, 2, 3, -1, 3, -1, 1 }; // -1 represents null
    }

    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
    
        public TreeNode() { }
        public TreeNode(int x) { val = x; left = null; right = null; }
    }

    public class BinaryTree
    {
        public TreeNode? root;

        public void createTree1()
        {
            root = new TreeNode(3);
            root.left = new TreeNode(2);
            TreeNode ptr = root.left;
            ptr.right = new TreeNode(3);

            root.right = new TreeNode(3);
            ptr = root.right;
            ptr.right = new TreeNode(1);
            return;
        }

        public void createTree2()
        {
            root = new TreeNode(3);
            root.left = new TreeNode(4);
            root.right = new TreeNode(5);

            TreeNode ptr = root.left;
            ptr.left = new TreeNode(1);
            ptr.right = new TreeNode(3);

            ptr = root.right;
            ptr.right = new TreeNode(1);
        }
    }
    public class Program
    {
        public int rob(TreeNode root)
        {
            int sum1 = 0, sum2 = 0;
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 0));

            while(queue.Count > 0)
            {
                Tuple<TreeNode, int> ptr = queue.Dequeue();
                if (ptr.Item2 % 2 == 0) sum1 += ptr.Item1.val;
                else sum2 += ptr.Item1.val;
                if (ptr.Item1.left != null) queue.Enqueue(new Tuple<TreeNode, int>(ptr.Item1.left, ptr.Item2 + 1));
                if (ptr.Item1.right != null) queue.Enqueue(new Tuple<TreeNode, int>(ptr.Item1.right, ptr.Item2 + 1));
            }

            return Math.Max(sum1, sum2);
        }
    }
}