// LeetCode 2
using System;
using System.Collections.Generic;

namespace _2
{
    public static class Globals
    {
        public static int[] l1 = { 0 };
        public static int[] l2 = { 0 };
        public static LinkedList<int> listNode1 = new LinkedList<int>(l1);
        public static LinkedList<int> listNode2 = new LinkedList<int>(l2);
    }
    public class Program
    {
        private void prettyPrint(LinkedList<int> ans)
        {
            LinkedListNode<int>? iterator = ans.First;
            Console.Write("LinkedList: ");
            while (iterator != null)
            {
                Console.Write($"{iterator.Value} --> ");
                iterator = iterator.Next;
            }
            Console.WriteLine("null");
            return;
        }
        public LinkedList<int> AddTwoNumbers(LinkedList<int> listNode1, LinkedList<int> listNode2)
        {
            LinkedList<int> ans = new LinkedList<int>();
            LinkedListNode<int>? iterator1 = listNode1.First;
            LinkedListNode<int>? iterator2 = listNode2.First;

            bool carry = false;
            while (iterator1 != null || iterator2 != null)
            {
                int sum = 0;
                if (iterator1 == null && iterator2 != null) sum = iterator2.Value;
                if (iterator1 != null && iterator2 == null) sum = iterator1.Value;
                if (iterator1 != null && iterator2 != null) sum = iterator1.Value + iterator2.Value;
                if (carry)
                {
                    sum += 1;
                    carry = false;
                }

                if (sum >= 10)
                {
                    sum -= 10;
                    carry = true;
                }

                ans.AddLast(sum);

                iterator1 = (iterator1 == null) ? iterator1 : iterator1.Next;
                iterator2 = (iterator2 == null) ? iterator2 : iterator2.Next;
            }

            if (carry) ans.AddLast(1);
            prettyPrint(ans);
            return ans;
        }
    }
}