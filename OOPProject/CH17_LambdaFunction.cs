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
        ArithmaticDelegate arithmatic = Add;
        arithmatic += (x, y) => { return x + y; };
        arithmatic += delegate (int x, int y) { return x + y; };//delegate keyword is used to write the anonymous function


        Activate((m) => { Console.WriteLine(m); }, "Hello world");
    }
    public int Add(int x, int y) { return x + y; }

    //Passing lambda function to a function
    public void Activate(Action<string> action, string message)
    {
        action.Invoke(message);
    }

}
