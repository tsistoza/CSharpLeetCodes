// LeetCode 617
using System;
using System.Collections.Generic;

namespace _617
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int _val=0, TreeNode? _left=null, TreeNode? _right=null)
        {
            this.val = _val;
            this.left = _left;
            this.right = _right;
        }
    }
    public class BinaryTree
    {
        public TreeNode? root;
        
        public void createBT1()
        {
            this.root = new TreeNode(1);

            // Level 1
            this.root.left = new TreeNode(3); 
            this.root.right = new TreeNode(2); 

            // Level 2
            TreeNode leftRoot = this.root.left;
            leftRoot.left = new TreeNode(5);
            return;
        }
        
        public void createBT2()
        {
            this.root = new TreeNode(2);

            // Level 1
            this.root.left = new TreeNode(1);
            this.root.right = new TreeNode(3);

            // Level 2
            TreeNode leftRoot = this.root.left;
            leftRoot.right = new TreeNode(4);
            TreeNode rightRoot = this.root.right;
            rightRoot.right = new TreeNode(7);
            return;
        }

        public void createBT3()
        {
            this.root = new TreeNode(1);
            return;
        }

        public void createBT4()
        {
            this.root = new TreeNode(1);
            this.root.left = new TreeNode(2);
            return;
        }

        public BinaryTree()
        {
            this.root = null;
        }
    }

    public class Program
    {
        public void levelTraversal(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.Write($"{node.val} ");
                if (node.left != null)  queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            Console.WriteLine();
            return;
        }

        private void preorderMerge(TreeNode? root1, TreeNode? root2)
        {
            if (root1 == null && root2 == null) return;
            
            // Merge Trees
            if (root1!.left != null && root2!.left != null) // If node exists in both trees
                root1.left.val += root2.left.val;
            if (root1!.right != null && root2!.right != null)
                root1.right.val += root2.right.val;


            if (root1!.left == null && root2!.left != null) // If node exists on one tree
                root1.left = new TreeNode(root2.left.val);
            if (root1!.right == null && root2!.right != null)
                root1.right = new TreeNode(root2.right.val);


            // Traverse
            if (root2!.left != null)  preorderMerge(root1.left, root2.left);
            if (root2!.right != null) preorderMerge(root1.right, root2.right);
            return;
        }
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            // Merge the roots first then left preorder traversal do it
            root1.val += root2.val;
            preorderMerge(root1, root2);
            return root1;
        }
    }
}