namespace CSharpBasics;
/// <summary>
/// String Manipulation
/// 1. Concatenation
/// 2. Splitting - to be completed after arrays
/// 3. Substring
/// </summary>
public class CH01_StringManipulation
{
    public static void Test()
    {
        Splitting();
    }
    public static void Concatenation()
    {
        //Concatenation
        Console.WriteLine("-----------Concatenation------------");
        string fullName = "Irfan" + " " + "Ali";
        Console.WriteLine(fullName);
        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your surname");
        string surname = Console.ReadLine();
        Console.WriteLine(surname +  " " + name);//Associativity is Left to Right


        //Placeholder Method
        Console.WriteLine("-----------Placeholder Method------------");
        Console.WriteLine("{0} {1}",name,surname);

        //Interpolation Method
        Console.WriteLine("-----------Interpolation Method------------");
        Console.WriteLine($"First Name = {name} Surname = {surname}");
    }
    public static void Splitting()//Important
    {
        string str = "Hello world";
        string[] strArray = str.Split(' ');
        //we can split with space, ',', '.' or any special characters
        //HW : Split a string which has atleast 10 names seperated by comma. split it by comma
    }
    public static void Substring()
    {
        ///substring is a part of string
        ///
        string str = "This is a .net class";
        //starting index of . is 10 and with four characters we can get .net
        string subString = str.Substring(10, 4);
        Console.WriteLine(subString);
        //using IndexOf
        subString = str.Substring(str.IndexOf('.'), 4);
        Console.WriteLine(subString);
        subString = str.Substring(str.IndexOf('c'), 5);
        Console.WriteLine(subString);
    }
    public static void IndexOf()
    {
        string str = "This is a .net class.";
        Console.WriteLine($"First position of . is {str.IndexOf('.')}");
        Console.WriteLine($"Last position of . is {str.LastIndexOf('.')}");
        char[] ch = new char[] { '.' };
        Console.WriteLine($"Position of . after 11 characters is {str.IndexOfAny(ch,11)}");
    }
}

