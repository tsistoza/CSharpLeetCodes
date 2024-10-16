namespace Solution {
    public class Helper {
        public bool IsPossibleToCutPath(int[ , ] grid) {
            int paths = 0;
            NumberOfPaths(grid, 0, 0, ref paths);
            //Console.WriteLine($"paths = {paths}");
            if (paths>1) { // too much paths
                return false;
            } else if (paths==1) { // one path
                return true;
            } else { // no paths
                return false;
            }
        }
        protected static void NumberOfPaths(int [ , ] grid, int m, int n, ref int paths) {
            int x = grid.GetLength(0)-1;
            int y = grid.GetLength(1)-1;
            //Console.WriteLine($"Currently placed on [{m},{n}]");
            if ((m==x) && (n==y)) { // reached the end increment paths+1
                Console.WriteLine("Path has been found");
                paths=paths + 1;
                Console.WriteLine(paths);
                return;
            }
            if ((m>x) || (n>y)) { //over the bounds of the grid
                return;
            }
            if(grid[m,n] == 1){ // keep going till [m,n]
                NumberOfPaths(grid, m+1, n, ref paths);
                NumberOfPaths(grid, m, n+1, ref paths);
            } else {
                return;
            }
        }
    } // class Helper
    public class MainN {
        public static void Main(string[] args) {
            Helper Obj = new Helper();
            int [ , ] grid = new int [3,3] { {1,1,1}, {1,0,0}, {1,1,1} };
            bool flag = Obj.IsPossibleToCutPath(grid);
            Console.WriteLine(flag);
            return;
        }
    } // class main
} // Namespace