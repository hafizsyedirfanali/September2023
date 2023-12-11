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
        public void Test()
        {
            int[][] matrix = new int[][]//Declaration with assignment
            { //          0  1  2  3
               new int[] {1, 2, 3, 4 }, //index 0
               new int[] {6, 7, 8, 9 }, //index 1
               new int[] {6, 7, 8, 9 }, //index 2
               new int[] {6, 7, 8, 9 }, //index 3
               new int[] {6, 7, 8, 9 }, //index 4
               new int[] {6, 7, 8 },    //index 5
            };// It is called as array of arrays (Jagged Array)
            matrix[2][2] = 18;//Writing 
            Console.WriteLine(matrix[1][2]);//Reading
        }
    }
}
