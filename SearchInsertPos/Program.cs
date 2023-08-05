using System;

namespace Solution
{
    public class Insertion
    {
        /*
        Given a sorted array of distinct integers and a target value. return the index
        if the target is found. If not, return the index where it would be if it were inserted
        in order. -> O(logn)
        */
        public int SearchInsert(int[] nums, int target){
            for(int i=0 ; i<nums.Length ; i++){
                if(nums[i] == target)
                    return i;
                if(nums[i] < target && i+1 < nums.Length && nums[i+1] > target)
                    return i+1;
                if(i == nums.Length-1)
                    return i+1;
            }
            return 0;
        } //function

    } //class
} //namespace


namespace mainN{
    public class Program
    {
        public static void Main(string[] args){
            //PARAMETERS
            int[] nums = {1,3,5,6,7,8,9};
            int target = 10;

            Solution.Insertion soln = new Solution.Insertion();
            int index = soln.SearchInsert(nums,target);
            Console.WriteLine(index);
        }//main
    }//class
}//main