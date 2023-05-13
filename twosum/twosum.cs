//#define DEBUG
using System;

namespace TwoSumProg{

    public class Solution {
        public int[] TwoSum(int[] nums, int target) {
            int[] solution;
            solution = new int[2];
            Array.Sort(nums,CompareNumbers);
            int LeftPointer = 0;
            int RightPointer = nums.GetLength(0) - 1;

            while(LeftPointer != RightPointer){
                #if DEBUG
                Console.WriteLine($"leftpointer = {nums[LeftPointer]},RightPointer = {nums[RightPointer]}");
                #endif
                if( (nums[LeftPointer] + nums[RightPointer]) < target )
                    LeftPointer++;
                else if((nums[LeftPointer] + nums[RightPointer]) > target)
                    RightPointer--;
                else if((nums[LeftPointer] + nums[RightPointer]) == target){
                    solution[0] = nums[LeftPointer];
                    solution[1] = nums[RightPointer];
                    break;
                }
            }

            return solution;
        }
        public int CompareNumbers(int x,int y){
            if (x<y)
                return -1;
            else if(x==y)
                return 0;
            else
                return 1;
        }

    } 
}

namespace mainN{
    class Program{
        public static void Main(string[] args){
            int[] numbers = {15,7,2,11};
            TwoSumProg.Solution soln = new TwoSumProg.Solution();
            numbers = soln.TwoSum(numbers,9);
            foreach(int i in numbers)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
}