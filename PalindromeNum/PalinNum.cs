using System;

namespace solution {
    public class Program {
        protected static bool PalinCheck(string number) {
            bool flag = false;
            int i=number.Length;
            foreach(char ch in number){
                i=i-1;
                flag = (ch==number[i]) ? true : false;
                if(!flag) break;
            }
            return flag;
        }
        public static void Main(string[] args) {
            string number = "32123";
            Console.WriteLine("Enter an integer");
            bool flag = PalinCheck(number);
            if (flag) {
                Console.WriteLine($"{number} is a Palindrome");
            } else {
                Console.WriteLine($"{number} is not a Palindrome");
            }
        }
    }
}