// LeetCode 113
using System;
using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left=null, TreeNode? right=null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinaryTree
{
    public TreeNode? root;

    public void createTree1()
    {
        // level 0
        this.root = new TreeNode(5);
        
        // level 1
        this.root.left = new TreeNode(4);
        this.root.right = new TreeNode(8);

        // level 2
        TreeNode ptrLeft = this.root.left;
        ptrLeft.left = new TreeNode(11);
        TreeNode ptrRight = this.root.right;
        ptrRight.left = new TreeNode(13);
        ptrRight.right = new TreeNode(4);

        // level 3
        ptrLeft = ptrLeft.left;
        ptrLeft.left = new TreeNode(7);
        ptrLeft.right = new TreeNode(2);

        ptrRight = ptrRight.right;
        ptrRight.left = new TreeNode(5);
        ptrRight.right = new TreeNode(1);
        return;
    }

    public void createTree2()
    {
        // level 0
        this.root = new TreeNode(1);

        // level1
        this.root.left = new TreeNode(2);
        this.root.right = new TreeNode(3);
    }

    public BinaryTree() { this.root = null; }
}

namespace Solution
{
    public class Program
    {
        public void prettyPrint(List<List<int>> paths)
        {
            foreach (List<int> path in paths)
            {
                Console.Write("{ ");
                foreach (int val in path)
                    Console.Write($"{val} ");
                Console.WriteLine("}");
            }
            Console.WriteLine();
            return;
        }
        public void preorderTraversal(List<List<int>> paths, List<int> path, TreeNode current, int currSum, int targetSum)
        {
            path.Add(current.val);
            currSum += current.val;
            if (current.left == null && current.right == null && currSum == targetSum) paths.Add(path);

            if (current.left != null) preorderTraversal(paths, new List<int>(path), current.left, currSum, targetSum);
            if (current.right != null) preorderTraversal(paths, new List<int>(path), current.right, currSum, targetSum);
            return;
        }
        public List<List<int>> PathSum(TreeNode root, int targetSum)
        {
            List<List<int>> paths = new List<List<int>>();
            preorderTraversal(paths, new List<int>(), root, 0, targetSum);
            return paths;
        }
        public static void Main()
        {
            Program obj = new Program();

            // TestCase 1
            BinaryTree tree = new BinaryTree();
            tree.createTree1();
            List<List<int>> paths = obj.PathSum(tree.root!, 22);
            obj.prettyPrint(paths);

            // TestCase 2
            BinaryTree tree1 = new BinaryTree();
            tree1.createTree2();
            paths = obj.PathSum(tree1.root!, 5);
            obj.prettyPrint(paths);
            return;
        }
    }
}