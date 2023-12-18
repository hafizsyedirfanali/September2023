namespace OOPProject;
/// <summary>
/// Lambda Functions are the functions/methods without reference variables (without name)
/// they have syntax as (input parameters)=>{ logic }
/// </summary>
public class CH17_LambdaFunction
{
    public delegate int ArithmaticDelegate(int a, int b);
    public void Test()
    {
        ArithmaticDelegate arithmatic = Add;//A function or method is assigned to a delegate
        arithmatic += (x, y) => { return x + y; };//a lambda function is assigned to a delegate
        arithmatic += delegate (int x, int y) { return x + y; };//delegate keyword is used to write the anonymous function


        Activate((m) => { Console.WriteLine(m); }, "Hello world");
        Activate(ActionFunction, "Hello world");

    }
    public void ActionFunction(string message)
    {
        Console.WriteLine(message);
    }
    public int Add(int x, int y) { return x + y; }

    //Passing lambda function to a function
    public void Activate(Action<string> action, string message)
    {
        action.Invoke(message);
    }

}
