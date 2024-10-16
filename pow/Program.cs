using System;

namespace Solution
{
    class Program
    {
        private static int CalcExpo(int expoBase,int expo){
            int result=expoBase;
            for(int i=1 ; i<expo ; i++)
                result*=expoBase;
            return result;
        }

        private static void Main(string[] args){
            //INPUT
            Console.WriteLine("Enter a base: ");
            string expoBase = Console.ReadLine();
            Console.WriteLine("Enter an exponent: ");
            string expo = Console.ReadLine();
            int num1 = Convert.ToInt32(expoBase);
            int num2 = Convert.ToInt32(expo);


            //CALCULATE POW
            int result = CalcExpo(num1,num2);
            Console.WriteLine($"The answer for base {num1} with exponent {num2} is: {result}");
            return;
        }
    }
}