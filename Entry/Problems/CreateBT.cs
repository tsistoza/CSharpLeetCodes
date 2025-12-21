// LeetCode 889
using System;
using System.Collections.Generic;

namespace _889
{
    public static class Globals
    {
        public static int[] preorder = { 1, 2, 4, 5, 3, 6, 7 };
        public static int[] postorder = { 4, 5, 2, 6, 7, 3, 1 };
        public static int[] preorder1 = { 1 };
        public static int[] postorder1 = { 1 };
    }

    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class BinaryTree
    {
        public TreeNode? root;

        public void LevelTraversal()
        {
            if (root == null)
            {
                Console.WriteLine("Root is empty");
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode root = queue.Dequeue();
                Console.Write($"{root.val} ");
                if (root.left != null) queue.Enqueue(root.left);
                if (root.right != null) queue.Enqueue(root.right);
            }
            Console.WriteLine();
            return;
        }
        public BinaryTree() { root = null; }
        public BinaryTree(TreeNode root) { this.root = root; }
    }


    public class Program
    {
        private TreeNode? constructTree(int preStart, int preEnd, int postStart, int[] preorder, Dictionary<int,int> idxToNum)
        {
            if (preStart > preEnd) return null;
            if (preStart == preEnd) return new TreeNode(preorder[preStart]);

            int leftRoot = preorder[preStart + 1];
            int numOfNodesInLeft = idxToNum[leftRoot] - postStart + 1;

            TreeNode? root = new TreeNode(preorder[preStart]);

            root.left = constructTree(preStart + 1, preStart + numOfNodesInLeft, postStart, preorder, idxToNum);

            root.right = constructTree(preStart + numOfNodesInLeft + 1, preEnd, postStart + numOfNodesInLeft, preorder, idxToNum);

            return root;
        }
        public TreeNode? ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            Dictionary<int,int> idxToNum = new Dictionary<int,int>();
            for (int i = 0; i < postorder.Length; i++) idxToNum[postorder[i]] = i;
            return constructTree(0, preorder.Length-1, 0, preorder, idxToNum);
        }
    }
}
