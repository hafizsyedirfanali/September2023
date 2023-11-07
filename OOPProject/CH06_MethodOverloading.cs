namespace OOPProject;
/// <summary>
/// Methods with same name is called method overloading.
/// This is only possible when all the overloaded methods have different signatures.
/// A signature of a method is the name with parameters and types & sequence of parameters.
/// consider three examples of the method signatures
/// 1. Print() - Its name is Print and it is parameterless
/// 2. Print(int count) - Its name is print and it has one int parameter
/// 3. Print(int count, string message) - Its name is print and it has <int> & <string> parameters
/// </summary>

public class CH06_MethodOverloading
{
    public void Test()
    {
        Print("this is a message", 10);
        Print(10,"this is a message");
    }
    public void Print()
    {

    }
    public void Print(int count)
    {

    }
    public void Print(int count, string message)
    {

    }
    public void Print(string message, int count)
    {

    }
}
