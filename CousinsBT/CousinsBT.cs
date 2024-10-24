using System;



namespace Solution
{
    public class BST
    {
        public TreeNode? root;

        public void createBST()
        {
            TreeNode nodePtrLeft;
            TreeNode nodePtrRight;
            // Root
            TreeNode root = new TreeNode(5);
            root.level = 0;

            // Level 2
            TreeNode newNode = new TreeNode(4);
            root.left = newNode;
            newNode = new TreeNode(9);
            root.right = newNode;
            nodePtrLeft = root.left;
            nodePtrRight = root.right;
            nodePtrLeft.level = 1;
            nodePtrRight.level = 1;

            // Level 3
            newNode = new TreeNode(1);
            nodePtrLeft.left = newNode;
            newNode = new TreeNode(10);
            nodePtrLeft.right = newNode;
            nodePtrLeft.left.level = 2;
            nodePtrLeft.right.level = 2;

            newNode = new TreeNode(7);
            nodePtrRight.right = newNode;
            nodePtrRight.right.level = 2;
            this.root = root;
            return;
        }
        public void printPreorder(TreeNode? node)
        {
            if (node == null) return;

            Console.WriteLine($" {node.val} ");

            printPreorder(node.left);
            printPreorder(node.right);
            return;
        }

        public void ReplaceValueInTree(TreeNode root)
        {
            // Base Case
            TreeNode newRoot = new TreeNode(0);
            newRoot.left = new TreeNode(0);
            newRoot.right = new TreeNode(0);
            ReplaceValueInLeftSubtree(root.left!, newRoot.left!);
            ReplaceValueInRightSubtree(root.right!, newRoot.right!);
            this.root = newRoot;
            return;
        }

        public void ReplaceValueInLeftSubtree(TreeNode root, TreeNode newRoot)
        {
            if (root.left != null)
            {
                newRoot.left = new TreeNode(GetKRightLevelValue(root.left.level, this.root!.right!));
                ReplaceValueInLeftSubtree(root.left, newRoot.left!);
            }
            if (root.right != null)
            {
                newRoot.right = new TreeNode(GetKRightLevelValue(root.right.level, this.root!.right!));
                ReplaceValueInLeftSubtree(root.right, newRoot.right!);
            }
            return;
        }

        public void ReplaceValueInRightSubtree(TreeNode root, TreeNode newRoot)
        {
            if(root.left != null)
            {
                newRoot.left = new TreeNode(GetKLeftLevelValue(root.left.level, this.root!.left!));
                ReplaceValueInRightSubtree(root.left, newRoot.left!);
            }
            if (root.right != null)
            {
                newRoot.right = new TreeNode(GetKLeftLevelValue(root.right.level, this.root!.left!));
                ReplaceValueInRightSubtree(root.right, newRoot.right!);
            }
            return;
        }

        public int GetKLeftLevelValue (int level, TreeNode root)
        {
            int sum = 0;
            if (level <= 1) return 0;
            if (root.level == level) return root.val;
            if (root.left != null) sum += GetKLeftLevelValue(level, root.left);
            if (root.right != null) sum += GetKLeftLevelValue(level, root.right);
            return sum;
        }

        public int GetKRightLevelValue(int level, TreeNode root)
        {
            int sum = 0;
            if (level <= 1) return 0;
            if (root.level == level) return root.val;
            if (root.left != null) sum += GetKRightLevelValue(level, root.left);
            if (root.right != null) sum += GetKRightLevelValue(level, root.right);
            return sum;
        }
    }
    public class TreeNode
    {
        public int val;
        public int level;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Program
    {
        public static void Main()
        {
            BST bst = new BST();
            bst.createBST();
            //bst.printPreorder(bst.root);
            bst.ReplaceValueInTree(bst.root!);
            bst.printPreorder(bst.root);
            return;
        }
    }

}