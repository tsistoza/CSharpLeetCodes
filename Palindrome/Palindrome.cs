using System;
using System.Collections.Generic;
namespace Solution{

    public class Palindrome{
        public int maxlength=0;

        public void substring(string s){
            List<char> palinString = new List<char>();
            int high=0,low=0,start=0;

            for(int i=0 ; i<s.Length ; i++){
                high = i+1;
                low  = i-1;
                while(high < s.Length-1 && s[high] == s[i])
                    high++;
                while(low >= 0 && s[low] == s[i])
                    low--;
                while(low >= 0 && high < s.Length-1 && s[high] == s[low]){
                    high++;
                    low--;
                }
                int length = high-low-1;
                if(maxlength < length){
                    maxlength = length;
                    start = low + 1;
                }
            }
            displaySubstring(s,start,start+maxlength-1);
            return;
        }

        public void displaySubstring(string s,int start,int end){
            Console.WriteLine($"The Longest Palindrome Substring with Length = {maxlength} is: ");
            for(int i = start ; i<end+1 ; i++){
                Console.Write($"{s[i]}");
            }
            Console.WriteLine();
            return;
        }

    }
}
namespace mainN{
    class Program{

        public static void Main(string[] args){
            Console.Write("Enter you String:");
            string temp = Console.ReadLine();
            
            Solution.Palindrome obj = new Solution.Palindrome();
            obj.substring(temp);
            Console.WriteLine("Press Any Key To Exit:");
            Console.ReadKey();

        }

    }
}