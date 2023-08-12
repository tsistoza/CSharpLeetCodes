using System;


namespace solution{
    class Program
    {
        public static int findPaths(int[ , ] grid,int row, int col){
            int sum=0;
            Console.WriteLine($"Row: {row} Col: {col}");
            if(grid[row,col] == 1){
                return 0;
            }

            if(grid[row,col] == 0){
                if (row<grid.GetLength(0)-1)
                    sum += findPaths(grid,row+1,col);
                if(col<grid.GetLength(1)-1)
                    sum += findPaths(grid,row,col+1);
            }

            //IF YOU REACH THE END W/O HITTING AN OBJECT RETURN 1
            if(row == grid.GetLength(0)-1 && col == grid.GetLength(1)-1)
                return 1;

            return sum;
        }
        public static void Main(string[] args){
            List<List<int>> pathList = new List<List<int>>();
            int[ , ] grid = { {0,1},{0,0} };
            int numOfPaths = findPaths(grid,0,0);
            Console.WriteLine($"The number of paths: {numOfPaths}");
            return;
        }
    }

}