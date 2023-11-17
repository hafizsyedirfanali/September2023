namespace CSharpBasics;
/// <summary>
/// A menu driven program is a software that runs infinitely. It will have a menu
/// to perform a list of different tasks including a normal exit.
/// For performing mathematical operations you can use Math Class, which is a math library.
/// </summary>

public class CH08_MenuDrivenProgram
{
    public void TestMath()
    {
        Math.Floor(4.5);
        Math.Ceiling(4.5);
    }
    public void Test()
    {
        TestCalculator();
    }
    public void TestCalculator()
    {
        bool continueProgram = true;
        while(continueProgram)
        {
            Console.Clear();
            Console.WriteLine("Welcome to My Calculator");
            Console.WriteLine("Press the appropriate number.");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtration");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char key = keyInfo.KeyChar;
            Console.Clear();
            switch (key)
            {
                case '1':
                    //Addition operation
                    Addition();
                    break;
                case '2':
                    //Subtration operation
                    Subtraction();
                    break;
                case '3':
                    //Multiplication operation
                    Multiplication();
                    break;
                case '4':
                    //Division operation
                    Division();
                    break;
                case '5':
                    //exit operation
                    continueProgram = false;
                    break;
                default:
                    //error message
                    Console.WriteLine("You pressed incorrect key. Press the correct option key.");
                    break;
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
        Console.WriteLine("Thanks for using My Calculator");
    }
    public void Addition()
    {
        try
        {
            Console.WriteLine("Addition Operation");
            Console.WriteLine("Enter two values");
            int value1 = Convert.ToInt32(Console.ReadLine());
            int value2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Sum of {value1} and {value2} is {value1 + value2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void Subtraction()
    {
        try
        {
            Console.WriteLine("Subtraction Operation");
            Console.WriteLine("Enter two values");
            int value1 = Convert.ToInt32(Console.ReadLine());
            int value2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Subtraction of {value2} from {value1} is {value1 - value2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void Multiplication()
    {
        try
        {
            Console.WriteLine("Multiplication Operation");
            Console.WriteLine("Enter two values");
            int value1 = Convert.ToInt32(Console.ReadLine());
            int value2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Multiplication of {value1} and {value2} is {value1 * value2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void Division()
    {
        try
        {
            Console.WriteLine("Division Operation");
            Console.WriteLine("Enter two values");
            int value1 = Convert.ToInt32(Console.ReadLine());
            int value2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Quotient of {value1} divided by {value2} is {value1 / value2}");
            Console.WriteLine($"Remainder of {value1} divided by {value2} is {value1 % value2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
