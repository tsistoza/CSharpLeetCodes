using System;
using System.Collections.Generic;

namespace Solution{
    
    class Median{

        public void displayMergedList(IEnumerator<int> iterator){
            Console.Write("The Merged List: [");
            while( iterator.MoveNext() )
                Console.Write($"{iterator.Current}, ");
            Console.WriteLine("]");
        }

        public float findMedian(List<int> nums1){
            float val;
            int length = nums1.Count;
            Console.WriteLine($"Length = {length}");
            if( (length%2)==1 ){
                int index  = (int) (length-1)/2;
                val = (float) ((nums1[index]));
                return val;
            }
            else{
                int index1 = (int) (length)/2;
                int index2 = index1-1;
                val = (float)  ( ((nums1[index1]) + (nums1[index2])) / 2.0);
                return val;
            }
        }
    }

}
namespace mainN{
    class Program{

        public static void Main(string[] args){
            Solution.Median soln = new Solution.Median();
            
            Console.WriteLine("Give any amount of numbers seperated by commas for Array1 (Ex. 1,2,3,4):");
            string foo1 = Console.ReadLine();
            string[] tokens1 = foo1.Split(",");
            List<int> nums1 = new List<int>();
            foreach(string s in tokens1)
                nums1.Add( Convert.ToInt32(s) );

            Console.WriteLine("Give any amount of numbers seperated by commas for Array2 (Ex. 1,2,3,4):");
            string foo2 = Console.ReadLine();
            string[] tokens2 = foo2.Split(",");
            List<int> nums2 = new List<int>();
            foreach(string s in tokens2)
                nums2.Add( Convert.ToInt32(s) );

            nums2.ForEach(item => nums1.Add(item));
            nums1.Sort();
            List<int>.Enumerator iterator = nums1.GetEnumerator();
            soln.displayMergedList(iterator);

            float val = (float) soln.findMedian(nums1);
            Console.WriteLine($"The Median is {val}");
            Console.WriteLine("Press Any Key To Exit:");
            Console.ReadKey();

        }
    }
}