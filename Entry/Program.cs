// Entry Point
using System;
using _899;

public class EntryPoint
{
    public static void Main()
    {
        Program obj = new Program();
        BinaryTree binaryTree = new BinaryTree();
        binaryTree.root = obj.ConstructFromPrePost(Globals.preorder, Globals.postorder);
        binaryTree.LevelTraversal();

        binaryTree = new BinaryTree();
        binaryTree.root = obj.ConstructFromPrePost(Globals.preorder1, Globals.postorder1);
        binaryTree.LevelTraversal();
        return;
    }
}