using System;

namespace Solution
{
    class Program
    {
        //ONLY CHECKD FOR 3x3 MATRIX
        protected static void Rotate(int[,] matrix){
            Console.WriteLine("\nRotated Matrix: ");
            int l = 0;
            int r = matrix.GetLength(1) - 1;
            while(l<r){
                for(int i=0 ; i<r-l ; i++){
                    int top = l;
                    int bottom = r;

                    //Starting from the top left work around the square and save the element
                    int topLeft = matrix[top,l+i];

                    //move bottom left into top left
                    matrix[top,l+i] = matrix[bottom-i,l];

                    //move bottom right into bottom left
                    matrix[bottom-i,l] = matrix[bottom,r-i];

                    //move top right into bottom right
                    matrix[bottom,r-i] = matrix[top+i,r];

                    //move top left into top right
                    matrix[top+i,r] = topLeft;
                }
                r--;
                l++;
            }
            printArray(matrix);
            return;
        }
        protected static void printArray(int[,] matrix){
            for(int i=0 ; i<matrix.GetLength(0) ; i++){
                for(int j=0 ; j<matrix.GetLength(1) ; j++){
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.Write("\n");
            }
            return;
        }
        public static void Main(string[] args){
            Program soln = new Program();
            int[ , ] matrix = new int [4,4] { {5,1,9,11},{2,4,8,10},{13,3,6,7},{15,14,12,16} };
            Console.WriteLine($"{matrix.GetLength(0)} Rows {matrix.GetLength(1)} Cols ");
            Console.WriteLine("ORIGINAL ARRAY: ");
            printArray(matrix);
            Rotate(matrix);
            return;
        }
    }
}