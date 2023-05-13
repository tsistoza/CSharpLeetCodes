//#define DEBUG
using System;
using System.Collections.Generic;

namespace Solution{

    public class LongestSubString{
        public int LengthofSubstring=0;
        
        protected void displayCurrentList(IEnumerator<char> iterator){
            while( iterator.MoveNext() )
                Console.Write($"{ iterator.Current }, ");
            Console.WriteLine();

            return;
        }

        public void findLongestSubStr(string someText){
            List<char> substring = new List<char>();

            char c = someText[0];
            substring.Add(c);
            int result=1;
            for(int i=1 ; i<someText.Length ; i++){

                c = someText[i];
                if( !substring.Contains(c) ){
                    substring.Add(c);
                    result++;
                }
                else{
                    #if (DEBUG)
                    List<char>.Enumerator iterator = substring.GetEnumerator();
                    displayCurrentList(iterator);
                    #endif
                    substring.Clear();
                    substring.Add(c);
                    result=1;
                }

                if(LengthofSubstring < result)
                        LengthofSubstring = result;
            }
            return;
        }
    }

}
namespace mainN{

    class Program{

        public static void Main(string[] args){
            
            Console.Write("Enter a String:");
            string input = Console.ReadLine();
            Solution.LongestSubString ans = new Solution.LongestSubString();
            ans.findLongestSubStr(input);
            Console.WriteLine($"The Longest Substring is: {ans.LengthofSubstring}");
            
            Console.WriteLine("Press Any Key to Exit:");
            Console.ReadKey();
            Console.WriteLine();
        }
    
    }
}