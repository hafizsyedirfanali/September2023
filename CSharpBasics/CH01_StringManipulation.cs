namespace CSharpBasics;
/// <summary>
/// String Manipulation
/// 1. Concatenation
/// 2. Splitting - to be completed after arrays and loops
/// 3. Substring
/// 4. Trimming
/// 5. Equals Method is used to compare two strings and returns boolean value
/// 6. Upper case and Lower case
/// </summary>
public class CH01_StringManipulation
{
    public static void Test()
    {
        UpperLowerCases();
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
        Console.WriteLine(surname + " " + name);//Associativity is Left to Right


        //Placeholder Method
        Console.WriteLine("-----------Placeholder Method------------");
        Console.WriteLine("{0} {1}", name, surname);

        //Interpolation Method
        Console.WriteLine("-----------Interpolation Method------------");
        Console.WriteLine($"First Name = {name} Surname = {surname}");
    }
    public static void UpperLowerCases()
    {
        string upperCamelCase = "HelloWorld";
        string lowerCamelCase = "helloWorld";
        string upperCase = "HELLOWORLD";
        string lowerCase = "helloworld";
        //Converting given string to UpperCase
        Console.WriteLine($"Upper case: {lowerCase.ToUpper()}");
        //Converting given string to LowerCase
        Console.WriteLine($"Lower case: {upperCase.ToLower()}");
        //Applications: Case Insensitive comparasions like: captcha
        string captcha = "Ab12cD";
        Console.WriteLine("Enter captcha");
        string enteredCaptcha = Console.ReadLine();
        bool isMatching = captcha.ToLower().Equals(enteredCaptcha.ToLower());
        Console.WriteLine($"Authenticated:{isMatching}");
        //Hw: Ask user to enter username and password
        //Compare them with stored username and password
        //Make use of trim and make the authentication case insensitive
    }
    public static void Trimming()
    {
        //Trimming is a method of removing extra characters from both the 
        //ends of string. the special characters may be
        //blank space \b, a tab \t, a new line character \n
        //Application: It is used in Usernames Passwords, etc
        //or wherever we compare two string 
        string name = "\tAsif \n";
        string trimmedName = name.Trim();
        //Application
        string password = "abcd1234";
        Console.WriteLine("Enter your password:");
        var enteredPassword = Console.ReadLine();
        bool isSame = password.Equals(enteredPassword.Trim());
        Console.WriteLine($"Authenticated:{isSame}");
    }
    public static void Splitting()//Important
    {
        string str = "Hello world";
        string[] strArray = str.Split(' ');
        //we can split with space, ',', '.' or any special characters
        //HW : Split a string which has atleast 10 names seperated by comma.
        //split it by comma
        string names = "Abid, Asif, Rehan, Jamil, Akash";
        string[] namesArray = names.Split(",");
        Console.WriteLine(namesArray[0]+","+ namesArray[1]);
    }
    public static void Substring()
    {
        ///substring is a part of string
        ///
        string str = "This is a .net class";
        //starting index of . is 10 and with four characters we can get .net
        string subString = str.Substring(startIndex:10,length:4);
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

