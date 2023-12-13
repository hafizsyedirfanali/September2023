namespace OOPProject;
/// <summary>
/// Delegates are the function pointers. It is an instance that holds address of a function.
/// Advantage:
/// 1. It is used as callback function.
/// 2. It makes the code loosely coupled (Decoupling of code)
/// </summary>

public class CH14_Delegates
{
    public delegate int ArithmaticDelegate(int a, int b);//Defination of Delegate
    public void Test()
    {
        //Declaration of Delegate
        ArithmaticDelegate arithmaticDelegate1 = new ArithmaticDelegate(Add);
        ArithmaticDelegate arithmaticDelegate2 = Add;

        //Calling a function using Delegate (Invoking)
        arithmaticDelegate1(10, 20);
        arithmaticDelegate1.Invoke(10, 20);

        //Calling a function directly
        Add(10, 22);

        TestA(Add);//here Sum is a callback function
    }

    public int Add(int x, int y)
    {
        return x + y;
    }
    public int Sum(int x, int y)
    {
        return x + y;
    }
    public int Increment(int x)
    {
        return x + 1;
    }

    ////------------------------------------------------------------------------
    ///
    public void TestA(ArithmaticDelegate a)
    {
        a(10, 12);
    }
    public void TestB(ArithmaticDelegate a)
    {
        a.Invoke(10, 12);
    }
    public void TestC(ArithmaticDelegate a)
    {
        a(10, 12);
    }

}
