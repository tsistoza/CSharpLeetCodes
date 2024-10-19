using System;
using System.Collections.Generic;


/* Leet Code 1305
 * Given two binary search trees root1 and root2, return a list containing all the integers from both trees sorted in ascending order.
 */

namespace Solution
{
    public class TreeNode
    {
        // Variables
        public List<int> list;
        public int id;
        public TreeNode left;
        public TreeNode right;
        
        // Constructors
        public TreeNode(int val=0, TreeNode left = null, TreeNode right = null)
        {
            this.id = val;
            this.left = left;
            this.right = right;
            this.list = new List<int>();
        }

        // Functions
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            TreeTraversal(root1);
            TreeTraversal(root2);
            this.list.Sort();
            IEnumerator<int> enumerator = this.list.GetEnumerator();
            while (enumerator.MoveNext()) 
            {
                Console.WriteLine(enumerator.Current);
            }
            return this.list;
        }

        public void TreeTraversal(TreeNode root1)
        {
            if (root1.left != null)
            {
                TreeTraversal(root1.left);
            }
            if (root1.right != null)
            {
                TreeTraversal(root1.right);
            }
            this.list.Add(root1.id);
            return;
        }

        public void createTreeNode1 ()
        {
            this.left = new TreeNode(1);
            this.right = new TreeNode(4);
        }

        public void createTreeNode2()
        {
            this.left = new TreeNode(0);
            this.right = new TreeNode(3);
        }
    }

    public class Program
    {
        public static void Main()
        {
            TreeNode root1 = new TreeNode(2);
            TreeNode root2 = new TreeNode(1);
            root1.createTreeNode1();
            root2.createTreeNode2();
            root2.GetAllElements(root1, root2);
            return;
        }
    }
}