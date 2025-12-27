// LeetCode 307
using System;
using System.Collections.Generic;

namespace _307
{
    public static class Globals
    {
        public static int[] nums = { 1, 3, 5 };
    }
    public class NumArray
    {
        private int[] ST;

        private void initST(int[] nums, int node, int left, int right)
        {
            if (left == right)
            {
                ST[node] = nums[left];
                return;
            }

            int mid = left + (right - left) / 2;

            if (2 * node >= ST.Length) return;
            initST(nums, 2 * node, left, mid);
            initST(nums, 2 * node + 1, mid + 1, right);
            ST[node] = ST[2 * node] + ST[2 * node + 1];
            return;
        }
        private void updateST(int node, int index, int val, int left, int right)
        {
            int mid = left + (right - left) / 2;

            if (left == right && left == index)
            {
                ST[node] = val;
                return;
            }

            if (index <= mid) 
                updateST(2 * node, index, val, left, mid);
            else 
                updateST(2 * node + 1, index, val, mid+1, right);

            ST[node] = ST[2 * node] + ST[2 * node + 1];
            return;
        }

        private int query(int node, int targetLeft, int targetRight, int left, int right)
        {
            if (node >= ST.Length) return 0;
            if (targetLeft == -1 || targetRight == -1) return 0;
            if (targetLeft == left && targetRight == right)
                return ST[node];

            int mid = left + (right - left) / 2;
            int ll=-1, lr=-1, rl=-1, rr=-1;

            // Possible options "|()| |"  "| (|) |"  "| |()|" 
            // Range is left of mid, range is split between mid, range is right of mid
            if (targetRight <= mid)
            {
                ll = targetLeft;
                lr = targetRight;
            }
            if (targetLeft > mid)
            {
                rl = targetLeft;
                rr = targetRight;
            }
            if (targetLeft <= mid && targetRight > mid)
            {
                ll = targetLeft;
                lr = mid;
                rl = mid + 1;
                rr = targetRight;
            }

            return query(2 * node, lr, ll, left, mid)
                + query(2 * node + 1, rl, rr, mid + 1, right);
        }
        public void Update(int index, int val)
        {
            int n = (ST.Length / 4);
            int mid = (n-1) / 2;
            updateST(1, index, val, 0, n - 1);
            return;
        }
        public int SumRange(int left, int right)
        {
            int n = (ST.Length / 4);
            return query(1, left, right, 0, n - 1);
        }
        public NumArray(int[] nums)
        {
            ST = new int[4 * nums.Length];
            initST(nums, 1, 0, nums.Length - 1);
        }
    }
}
