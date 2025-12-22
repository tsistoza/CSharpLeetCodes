// LeetCode 94
using System;
using System.Collections.Generic;

namespace _94
{
    public static class Globals
    {
        public static int[] root = { 1 }; // -101 represent null
    }


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
    public class Program
    {
        public static void PrettyPrint(IList<int> list)
        {
            Console.Write("{ ");
            foreach (int i in list)
                Console.Write($"{i}, ");
            Console.WriteLine("}");
            return;
        }
        public static TreeNode? BuildTree(int[] root, int index)
        {
            if (index >= root.Length) return null;
            TreeNode? node = (root[index] == -101) ? null : new TreeNode(root[index]);
            
            if (node != null)
            {
                Console.WriteLine(node.val);
                node!.left = BuildTree(root, 2 * index + 1);
                node!.right = BuildTree(root, 2 * index + 2);
            }

            return node;
        }
        private void Inorder(TreeNode? root, ref List<int> inorderList)
        {
            if (root == null) return;

            if (root.left != null)
                Inorder(root.left, ref inorderList);
            inorderList.Add(root.val);
            if (root.right != null)
                Inorder(root.right, ref inorderList);

            return;
        }
        public IList<int> InorderTraversal(TreeNode? root)
        {
            List<int> inorderList = new List<int>();
            if (root == null) return inorderList;

            Inorder(root, ref inorderList);
            return inorderList;
        }
    }
}