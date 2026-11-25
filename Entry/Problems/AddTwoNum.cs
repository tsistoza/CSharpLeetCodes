// LeetCode 2
using System;
using System.Collections.Generic;

namespace _2
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int _val=0, ListNode? _next=null)
        {
            val = _val;
            next = _next;
        }
    }
    public static class Globals
    {
        public static int[] arr1 = { 9, 9, 9, 9, 9, 9, 9 };
        public static int[] arr2 = { 9, 9, 9, 9 };
    }
    public class Program
    {
        private void prettyPrint(ListNode root)
        {
            Console.Write("LinkedList: ");
            ListNode? ptr = root;
            while (ptr != null)
            {
                Console.Write($"{ptr.val} --> ");
                ptr = ptr.next;
            }
            Console.WriteLine("null\n");
            return;
        }
        public ListNode CreateList(int[] arr)
        {
            int n = arr.Length;
            ListNode root = new ListNode(arr[0]);
            ListNode ptr = root;
            for (int i=1; i<n; i++)
            {
                ptr.next = new ListNode(arr[i]);
                ptr = ptr.next;
            }
            return root;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode root = new ListNode();
            bool carry = false;

            ListNode? ptr1 = l1, ptr2 = l2, currPtr = null;
            while (ptr1 != null || ptr2 != null)
            {
                int val1 = 0, val2 = 0;
                if (ptr1 != null) val1 = ptr1.val;
                if (ptr2 != null) val2 = ptr2.val;

                int sum = (carry) ? val1 + 1 + val2 : val1 + val2;
                if (sum > 9)
                {
                    carry = true;
                    sum -= 10;
                } else
                {
                    carry = false;
                }

                if (currPtr == null)
                {
                    root.val = sum;
                    currPtr = root;
                }
                else
                {
                    currPtr.next = new ListNode(sum);
                    currPtr = currPtr.next;
                }

                if (ptr1 != null) ptr1 = ptr1.next;
                if (ptr2 != null) ptr2 = ptr2.next;
            }

            if (carry) currPtr!.next = new ListNode(1);
            prettyPrint(root);
            return root;
        }
    }
}