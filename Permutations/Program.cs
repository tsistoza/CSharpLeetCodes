using System;
using System.Collections;

namespace solution
{
    public class Solution
    {
        public static void Permute(int[] nums) {
            List<int> numsList = new List<int>(nums);

            //Create List of Lists
            List<List<int>> list = new List<List<int>>();

            //Generate Permutations
            foreach(List<int> sublist in helper(numsList))
                list.Add(sublist);
            
            printList(list);
        }

        public static IEnumerable<List<int>> helper(List<int> sublist) { //Since we are returning multiple iterators use IEnumerable too iterate over them.
            if(sublist.Count == 2){
                yield return new List<int> (sublist);
                yield return new List<int> {sublist[1],sublist[0]};
            }
            else{
                foreach(int i in sublist){ //CHECK FOR ALL PERMUTATIONS OF i.
                    var rlist = new List<int> (sublist);
                    rlist.Remove(i);
                    foreach(List<int> retList in helper(rlist) ){
                        retList.Insert(0,i); 
                        yield return retList;
                    }
                }
            }
        }

        public static void printList(List<List<int>> list){
            Console.WriteLine("The Permutations are: ");
            int index=0;
            foreach(List<int> value in list)
            {
                Console.WriteLine($"Permutation #{index}: ");
                foreach(int item in value){
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                index++;
            }
            return;
        }

        public static void Main(string[] args){
            int[] nums = {1,2,3};
            Permute(nums);
            return;
        }
    }
}