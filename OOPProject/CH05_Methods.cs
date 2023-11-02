namespace OOPProject;

public class CH05_Methods
{
    public void Test()
    {
        PrintMessage();
        float temperature = GetTemperature();
        int incrementedValue = IncrementValue(21);
        int sumResult = Sum(10, 11);
        (int quotient, int remainder) = Divide(10, 3);
    }
    //parameterless function without return type (void)
    //This method will neither take any value nor returns any value
    //It just performs the instructions
    public void PrintMessage()
    {
        Console.WriteLine("Hello world");
    }
    //Parameterless function with return type
    //this method will not take any value but will return some value
    public float GetTemperature()
    {
        //float temperature = 27.5f;
        //return temperature;
        return 27.5f;
    }
    //Parameterized function with return type
    //This method will accept a value and return a value
    public int IncrementValue(int value)
    {
        value += 1;
        return value;
    }
    //Parameterized function with return type
    //This method will accept two values and return a value
    public int Sum(int a, int b)
    {
        //int result = a + b;
        //return result;
        return a + b;
    }
    //Parameterized function with return type
    //this method will accept two values and return two values
    //this method will divide two values and retrun quotient and remainder
    public (int Quotient, int Remainder) Divide(int a, int b)
    {
        int quotient = a / b;
        int remainder = a % b;
        return (quotient,  remainder);
    }
}
