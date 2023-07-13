using System;
using System.Collections.Generic;

namespace Solution{
    class Method{

        public LinkedList<int> CreateLinkedList(List<int> createList){
            LinkedList<int> linklist = new LinkedList<int>(createList);
            /*
            //First Node
            LinkedListNode<int> Node = new LinkedListNode<int>(createList.First());
            Console.WriteLine($"Creating a node with value: {createList.First()}");

            LinkedList<int> linklist = new LinkedList<int>();
            linklist.AddFirst(Node);

            //Last Node
            LinkedListNode<int> LastNode = new LinkedListNode<int>(createList.Last());
            Console.WriteLine($"Creating a node with value: {createList.Last()}");
            linklist.AddLast(LastNode);
            Console.WriteLine($"The Last node is: {linklist.Last()}");

            iterator.MoveNext();
            while( iterator.MoveNext() ){
                int i = 0;
                if(iterator.Current == LastNode.Value)
                    break;
                LinkedListNode<int> NextNode = new LinkedListNode<int>(iterator.Current);
                Console.WriteLine($"Creating a node with value: {iterator.Current}");
                linklist.AddAfter(Node,NextNode);
                Node = NextNode;
            }
            */
            return linklist;
        }//Function

        protected void DisplayLinkedList(LinkedList<int> linkedlist){
            LinkedList<int>.Enumerator iterator = linkedlist.GetEnumerator();
            Console.WriteLine("The Current LinkedList is as follows: ");
            while( iterator.MoveNext() ) {
                Console.WriteLine($"Current Node Value is: {iterator.Current}");
            }
        }

        public void RemoveNthNode(LinkedList<int> linkedlist,int nthnode){
            int ptr = nthnode-1;
            DisplayLinkedList(linkedlist);
            LinkedListNode<int> lastNode = linkedlist.Last;
            while( ptr > 0 ){
                lastNode = lastNode.Previous;
                ptr--;
            }
            Console.WriteLine($"The current node value is: {lastNode.Value}. Removing This Node...");
            linkedlist.Remove(lastNode);
            Console.WriteLine($"The Current List after removing given node is ");
            DisplayLinkedList(linkedlist);
        }

    }//Class
}//Namespace

namespace mainN{
    class Program{
        public static void Main(string[] args){
            //Using the list from C#
            List<int> Array = new List<int>();

            //User Input
            Console.WriteLine("Enter a Linked List:");
            string foo = Console.ReadLine();
            Console.WriteLine("Enter the nth node to remove: ");
            string nthnode = Console.ReadLine();
            int nth = Convert.ToInt32(nthnode);

            //Put into List
            string[] tokens = foo.Split(",");
            foreach(string s in tokens){
                Array.Add(Convert.ToInt32(s));
            }
            Solution.Method soln = new Solution.Method();
            LinkedList<int> tempList = soln.CreateLinkedList(Array);
            soln.RemoveNthNode(tempList,nth);
        }
    }
}