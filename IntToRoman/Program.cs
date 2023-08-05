using System;
/*
    KEY NOTES:
    M - 1000
    CM - 900
    D - 500
    CD - 400
    C - 100
    XC - 90
    L - 50
    XL - 40
    X - 10
    IX - 9
    V - 5
    IV - 4
    I - 1
*/

namespace Solution
{
    class Program
    {
        public static string IntToRoman(int number){
            string temp = "";
            while(number > 0){
                if (number >= 1000){
                    number-=1000;
                    temp = temp.Insert(temp.Length,"M");
                }
                else if(number >= 900){
                    number-=900;
                    temp = temp.Insert(temp.Length,"CM");
                }
                else if(number >= 500){
                    number-=500;
                    temp = temp.Insert(temp.Length,"D");
                }
                else if(number >= 400){
                    number-=400;
                    temp = temp.Insert(temp.Length,"CD");
                }
                else if(number >= 100){
                    number-=100;
                    temp = temp.Insert(temp.Length,"C");
                }
                else if(number >= 90){
                    number-=90;
                    temp = temp.Insert(temp.Length,"XC");
                }
                else if(number >= 50){
                    number-=50;
                    temp = temp.Insert(temp.Length,"L");
                }
                else if(number >= 40){
                    number-=40;
                    temp = temp.Insert(temp.Length,"XL");
                }
                else if(number >= 10){
                    number-=10;
                    temp = temp.Insert(temp.Length,"X");
                }
                else if(number >= 9){
                    number-=9;
                    temp = temp.Insert(temp.Length,"IX");
                }
                else if(number >= 5){
                    number-=5;
                    temp = temp.Insert(temp.Length,"V");
                }
                else if(number >= 4){
                    number-=4;
                    temp = temp.Insert(temp.Length,"IV");
                }
                else if(number >= 1){
                    number-=1;
                    temp = temp.Insert(temp.Length,"I");
                }
            }
            return temp;
        }
        public static void Main(string[] args){
            Console.Write("Enter a Number: ");
            string number = Console.ReadLine();
            int target = Convert.ToInt32(number);
            string Numeral = IntToRoman(target);
            Console.WriteLine(Numeral);
            return;
        }//main
    }//class
}//namespace