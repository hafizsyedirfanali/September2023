namespace OOPProject;
/// <summary>
/// A method can be called by passing a value or a reference.
/// where a reference is an address of a variable or object.
/// the variable that holds the address is called reference variable or reference object.
/// </summary>
public class CH07_CallByReference
{
    public void Test()
    {
        int a = 30; int b = 20;
        int result = AddByValue(a, b);

        AddByReference(in a, in b, out result);//This call will send address of a, b & result variables
        SubtractByReference(ref a, ref b, ref result);
    }
    public int AddByValue(int a, int b)//This is an example of call by value
    {
        return a + b;
    }
    //Example1 : Call by reference using in & out keywords
    public void AddByReference(in int a, in int b, out int result)
        //here a will hold the address of variable a in test method, similar is the case of b and result
        //the variables marked with "in" keyword can read the incoming value but cannot write,
        //the variable marked with "out" keyword must write the value before leaving the method
    {
        result = a + b + 10;
    }

    //Example2 : Call by reference using ref keyword
    //this ref keyword allows both reading and writing
    public void SubtractByReference(ref int a, ref int b, ref int result)
    {
        a += 1;
        b += 1;
        result = a - b;
    }

    //We learnt use of out keyword in parsing/casting chapter CH03_TypeConversion in CSharpBasics
}
