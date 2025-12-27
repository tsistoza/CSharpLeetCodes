// LeetCode 2415
using System;
using System.Collections.Generic;

namespace _2415
{
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
        public TreeNode root;

        private void createTree1() 
        {
            // Level 1
            this.root.left = new TreeNode(3);
            this.root.right = new TreeNode(5);

            // Level 2
            TreeNode ptr = this.root.left;
            ptr.left = new TreeNode(8);
            ptr.right = new TreeNode(13);

            ptr = this.root.right;
            ptr.left = new TreeNode(21);
            ptr.right = new TreeNode(34);
            return;
        }

        private void createTree2()
        {
            this.root.left = new TreeNode(13);
            this.root.right = new TreeNode(11);
            return;
        }

        public TreeNode ReverseOddLevels()
        {
            Queue<Tuple<TreeNode, int>> levelTraversal = new Queue<Tuple<TreeNode, int>>();
            levelTraversal.Enqueue(new Tuple<TreeNode, int>(this.root, 0));
            int level = 0;
            List<TreeNode> order = new List<TreeNode>();
            List<int> ints = new List<int>();

            while(levelTraversal.Count > 0)
            {
                TreeNode ptr;
                Tuple<TreeNode, int> top = levelTraversal.Dequeue();
                ptr = top.Item1;
                if (top.Item2 % 2 == 1)
                {
                    ints.Add(top.Item1.val);
                    order.Add(top.Item1);
                }
                if (ptr.left != null) levelTraversal.Enqueue(new Tuple<TreeNode, int>(ptr.left, top.Item2+1));
                if (ptr.right != null) levelTraversal.Enqueue(new Tuple<TreeNode, int>(ptr.right, top.Item2+1));
                if (top.Item2 % 2 == 0 && level < top.Item2)
                {
                    ReverseLevel(order, ints);
                    level = top.Item2;
                }
            }

            ReverseLevel(order, ints);
            return this.root;
        }

        public void levelTreeTraversal()
        {
            if (this.root == null) return;
            Queue<TreeNode> order = new Queue<TreeNode>();
            order.Enqueue(this.root);

            while (order.Count > 0)
            {
                TreeNode ptr = order.Dequeue();
                Console.Write($"{ptr.val} ");

                if (ptr.left != null) order.Enqueue(ptr.left);
                if (ptr.right != null) order.Enqueue(ptr.right);
            }
            Console.WriteLine();
            return;
        }

        private void ReverseLevel(List<TreeNode> nodes, List<int> reverse)
        {
            reverse.Reverse();
            int index = 0;
            foreach (TreeNode node in nodes)
                node.val = reverse[index++];
            reverse.Clear();
            nodes.Clear();
            return;
        }

        public BinaryTree(int num)
        {
            TreeNode root = new TreeNode(num);
            this.root = root;
            if (this.root.val == 2) createTree1 ();
            if (this.root.val == 7) createTree2 ();
        }
    }
}
