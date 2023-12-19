namespace CSharpBasics;
/// <summary>
/// An array is a non-primitive, Static, Linear data structure.
/// </summary>
public class CH07_Arrays
{
    public void Test()
    {

    }
    public void TestIntegerArray()
    {
        int[] rollNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
    public void TestStringArray()
    {
        string[] names = new string[] { "mehvish", "suboor", "adil", "shahnawaz", "adnan", "maaz", "rizwan" };
    }
    public void TestCharacterArray()
    {
        char[] chars = new char[] { 's', 'u', 'b', 'o', 'o', 'r' };
    }
    //whats new in .net7, 8
   
    public class JaggedArray
    {
        /// <summary>
        /// Jagged array is an array of arrays of different sizes/lengths.
        /// </summary>
        public void Test()
        {
            int[][] matrix = new int[][]//Declaration with assignment
            { //          0  1  2  3
               new int[] {1, 2, 3, 4 }, //index 0
               new int[] {6, 7, 8, 9 }, //index 1
               new int[] {6, 7, 8, 9 }, //index 2
               new int[] {6, 7, 8, 9, 0 }, //index 3
               new int[] {6, 7, 8, 9 }, //index 4
               new int[] {6, 7, 8 },    //index 5
            };// It is called as array of arrays (Jagged Array)
            matrix[2][2] = 18;//Writing 
            Console.WriteLine(matrix[1][2]);//Reading
        }
    }
    public class TwoDimnesionArray
    {
        /// <summary>
        /// Two Dimension array is a collection of two dimensions of an item.
        /// it is a 2D matrix like 2 x 2, 3 x 3, 2 x 3 etc
        /// 
        /// </summary>
        public void Test()
        {
            /// 2 X 2 Matrix
            ///   0  1
            /// [ 1  2 ] - 0
            /// [ 3  4 ] - 1
            int[,] matrix2x2 = new int[2, 2];//Declaration
            //Value assignment
            matrix2x2[0,0] = 1;
            matrix2x2[0,1] = 2;
            matrix2x2[1,0] = 3;
            matrix2x2[1,1] = 4;

            //Console.WriteLine(matrix2x2[0,0]);
            //Reading values using for loop
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(matrix2x2[row,col] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
    public class ThreeDimensionArray
    {
        /// <summary>
        /// Three Dimension array is a collection of three dimensions of an item.
        /// it is a 3D matrix like 2 x 2 x 2, 3 x 3 x 3, 1 x 2 x 3 etc
        /// </summary>
        public void Test()
        {
            int[,,] matrix2x2x2 =
            {
                {
                    {
                        1, 2
                    },
                    {
                        3, 4
                    }
                },
                {
                    {
                        5, 6
                    },
                    {
                        7, 8
                    }
                }
            };
            matrix2x2x2[0,0,0] = 1;
            for (int i = 0;i < 2; i++)
            {
                for(int j = 0;j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        Console.Write(matrix2x2x2[i, j, k]);
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("\n\n");
            }
        }
    }
    public class FourDimensionArray
    {
        public void Test()
        {
            int index = 0;
            int[,,,] matrix4d = new int[4, 4, 4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            matrix4d[i, j, k, l] = index++;
                        }
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            Console.Write(matrix4d[i, j, k, l]+"  ");
                        }
                        Console.WriteLine("");
                    }
                    Console.WriteLine("-------------");
                }
                Console.WriteLine("=================");
            }
        }
    }
}
