namespace CSharpBasics;

public class CH01_StringManipulation
{
    public static void Test()
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
}

