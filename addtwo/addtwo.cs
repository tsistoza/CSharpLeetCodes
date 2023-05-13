/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 #define DEBUG
 using System;
 using System.Collections.Generic;

namespace mainN{
    public class Solution {

        public void displayCurrentList(IEnumerator<int> iterator){

            Console.WriteLine("The Current List goes as:");
            Console.Write("[");
            while( iterator.MoveNext() )
                Console.Write($"{iterator.Current}, ");
            Console.WriteLine("]");
            return;

        }
        public LinkedList<int> createLinkedList(LinkedList<int> somelist){

            Random rnd = new Random();
            int listLength1 = rnd.Next(0,5);
            for(int i=0 ; i<=listLength1 ; i++)
                somelist.AddLast( rnd.Next(0,9) );
            LinkedList<int>.Enumerator iterator = somelist.GetEnumerator();
            displayCurrentList(iterator);
            return somelist;

        }

        public LinkedList<int> AddTwoNumbers(LinkedList<int> l1, LinkedList<int> l2) {
            LinkedList<int> solution = new LinkedList<int>();
            LinkedList<int>.Enumerator pointer1 = l1.GetEnumerator();
            LinkedList<int>.Enumerator pointer2 = l2.GetEnumerator();
            var str1 = pointer1.Current.ToString();
            var str2 = pointer2.Current.ToString();


            while( pointer1.MoveNext() ){
                string tempstr1 = pointer1.Current.ToString();
                str1 += tempstr1;
            }
            while( pointer2.MoveNext() ){
                string tempstr2 = pointer2.Current.ToString();
                str2 += tempstr2;
            }

            #if (DEBUG)
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            #endif

            int val1 = Convert.ToInt32(str1);
            int val2 = Convert.ToInt32(str2);

            #if (DEBUG)
            Console.WriteLine($"val1 = {val1}");
            Console.WriteLine($"val2 = {val2}");
            #endif

            int ans = val1 + val2;
            string soln = ans.ToString();
            foreach(char c in soln){
                int temp = (int)Char.GetNumericValue(c);
                solution.AddFirst(temp);
            }
            LinkedList<int>.Enumerator solnIterator = solution.GetEnumerator();
            displayCurrentList(solnIterator);
            return solution;
        }

        public static void Main(string[] args){
            Random rnd = new Random();
            Solution soln = new Solution();

            //Create LinkedList
            LinkedList<int> lln      = new LinkedList<int>();
            LinkedList<int> lln2     = new LinkedList<int>();
            LinkedList<int> solution = new LinkedList<int>();
            lln  = soln.createLinkedList(lln);
            lln2 = soln.createLinkedList(lln2);

            //SOLUTION
            solution = soln.AddTwoNumbers(lln,lln2);
            

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.WriteLine();

        }


    } 
}