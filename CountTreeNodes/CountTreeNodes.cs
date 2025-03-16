// LeetCode 222
using System;
using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int _val = 0, TreeNode? _left = null, TreeNode? _right = null)
    {
        this.val = _val;
        this.left = _left;
        this.right = _right;
    }

}

public class Tree
{
    public TreeNode? root;

    public TreeNode? createTree(List<int> nodes, int index)
    {
        TreeNode? root = null;
        if (index < nodes.Count)
        {
            root = new TreeNode(nodes[index]);
            root.left = createTree(nodes, 2 * index + 1);
            root.right = createTree(nodes, 2 * index + 2);
        }
        return root;
    }

    public Tree (List<int> _nodes)
    {
        if (_nodes.Count == 0)
        {
            root = null;
            return;
        }
        root = createTree(_nodes, 0);
    }
}

public static class Globals
{
    public static List<int> nodes = new List<int>() { 1, 2, 3, 4, 5, 6 };
    public static List<int> nodes1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
}

namespace Solution
{
    public class Program
    {
        public int findHeight(TreeNode? root)
        {
            if (root == null) return 0;
            int height = 0;
            TreeNode ptr = root;
            while (ptr.left != null)
            {
                height++;
                ptr = ptr.left;
            }
            return height;
        }
        public bool FoundNode(int leave, TreeNode root, int maxLeavesAtNode)
        {
            if (maxLeavesAtNode == 2)
                return (leave == 0) ? root.left != null : root.right != null;

            if (leave <= (int)(maxLeavesAtNode / 2)) return FoundNode(leave, root.left!, maxLeavesAtNode / 2);
            return FoundNode(leave / 2, root.right!, maxLeavesAtNode / 2);
        }
        public int CountNodes(TreeNode? root)
        {
            if (root == null) return 0;
            int height = findHeight(root);
            if (height == 0) return 1;

            int maxCount = (int)Math.Pow(2, height+1) - 1;
            int leavesCount = (int)Math.Pow(2, height);

            // Binary Search
            int left = 0;
            int right = leavesCount; // this is the rightmost leaf node of root
            while (left < right)
            {
                int middle = left + (right - left) / 2;
                if (FoundNode(middle, root, leavesCount))
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            int count = maxCount - leavesCount;
            return count + left;
        }
        public static void Main()
        {
            // createTree
            Tree tree = new Tree(Globals.nodes);

            // Test Cases
            Program obj = new Program();
            Console.WriteLine(obj.CountNodes(tree.root));

            tree = new Tree(Globals.nodes1);
            Console.WriteLine(obj.CountNodes(tree.root));

            tree = new Tree(new List<int> { 1 });
            Console.WriteLine(obj.CountNodes(tree.root));
            return;
        }
    }
}