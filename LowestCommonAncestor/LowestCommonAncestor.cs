// LeetCode 1123
using System;
using System.Collections.Generic;

public static class Globals
{
    public static int[] tree = { 1 }; // -1 denotes a null node
}

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int _val=0, TreeNode? _left=null, TreeNode? _right=null)
    {
        val = _val; left = _left; right = _right;
    }
}

public class Tree
{
    public TreeNode? root;

    private TreeNode? createTree(int[] tree, int index)
    {
        TreeNode? node = null;

        if (index < tree.Length && tree[index] != -1) node = new TreeNode(tree[index]);

        if (node != null)
        {
            node.left = createTree(tree, 2*index + 1);
            node.right = createTree(tree, 2*index + 2);
        }

        return node;
    }
    private void levelTreeTraversal(TreeNode? root)
    {
        if (root == null) return;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            Console.Write($"{node.val} ");

            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }
        Console.WriteLine();
        return;
    }

    public Tree(int[] _tree)
    {
        this.root = createTree(_tree, 0);
        this.levelTreeTraversal(this.root);
    }
}

namespace Solution
{
    public class Program
    {
        public void postorder(TreeNode root, int currDepth, ref int maxDepth)
        {
            maxDepth = Math.Max(currDepth, maxDepth);

            if (root.left != null) postorder(root.left, currDepth+1, ref maxDepth);
            if (root.right != null) postorder(root.right, currDepth+1, ref maxDepth);

            return;
        }

        public TreeNode? findLCA(TreeNode curr, int currDepth, int maxDepth)
        {
            if (currDepth == maxDepth-1)
            {
                if (curr.left != null && curr.right != null) return curr;
                if (curr.left != null && curr.right == null) return curr.left;
                if (curr.left == null && curr.right != null) return curr.right;
                return null;
            }

            TreeNode? left = null;
            TreeNode? right = null;
            // Split into left and right subtrees
            if (curr.left != null) left = findLCA(curr.left, currDepth + 1, maxDepth);
            if (curr.right != null) right = findLCA(curr.right, currDepth + 1, maxDepth);

            if (left != null && right == null) return left;
            if (left == null && right != null) return right;
            if (left == null && right == null) return null;
            return curr;
        }
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            int maxDepth = 0;
            postorder(root, 0, ref maxDepth);

            if (maxDepth == 0) return root;

            return findLCA(root, 0, maxDepth)!;
            
        }
        public static void Main()
        {
            Tree bt = new Tree(Globals.tree);
            
            Program obj = new Program();
            Console.WriteLine(obj.LcaDeepestLeaves(bt.root!).val);
            return;
        }
    }
}