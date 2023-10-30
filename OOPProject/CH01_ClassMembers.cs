namespace OOPProject;
/// <summary>
/// A class is a collection of class members.
/// The class which is within namespace is called Type.
/// A class can have 
/// 1. Properties - these are public customized variables in UpperCamelCase
/// 2. Fields     - these are private variables in LowerCamelCase
/// 3. Methods    - these are functions in UpperCamelCase
/// 4. Classes    - these are nested classes in UpperCamelCase
/// 5. Structs    - these are same as classes with a little difference in UpperCamelCase
/// 6. Constructor- It is a method that is called during instantiation
/// 7. Destructor - It is a method that is called during disposal
/// </summary>
public class CH01_ClassMembers
{
    //Constructor: it is method, which has name identical to the class name
    //it does not return value. it is always called during class instantiation
    public CH01_ClassMembers() 
    {
        Age = 11;
    }

    //Properties
    public string Name { get; set; } //get means read and set means write
    //public string Hidden { set; } A property without get is not possible
    public int Age { get; } = 10;//This is direct assignment
    //This is get only property,
    //whose value can be assigned either directly or
    //through constructor
    public string Gender { get; private set; }

    //Functions
    public void Test()//this line is defination of Method & following lines enclosed in {  } is its implementation
    {
        Name = "Irfan Ali";
        Gender = "Male";
    }
    public void SetValue()
    {
        Name = "Irfan";
    }
    public void PrintValue()
    {
        Console.WriteLine(Name);
    }
    //Fields
    private int count = 10;

    //Class
    public class NestedClass
    {

    }
    //Structure
    public struct NestedStruct
    {

    }

    //Destructor
    ~CH01_ClassMembers()
    {

    }
}

public class Visitor
{
    public Visitor()
    {
        Counter = 10;
    }
    public int Counter { get; set; }
    public void Increment()
    {
        Counter += 1;
    }
    public void Decrement()
    {
        Counter -= 1;
    }
}

///Task1:
///Calculator
///Properties- Num1, Num2, Result
///Method - Add, Substract, Multiply, Divide (quotient), PrintResult
///Task2:Messenger 
///properties - Message
///Methods - SetMessage & PrintMessage
/// 
public class Calculator
{
    public int Num1 { get; set; }
    public int Num2 { get; set; }
    public int Result { get; set; }
    public void Add()
    {
        Result = Num1 + Num2;
    }
    public void Subtract()
    {
        Result = Num1 - Num2;
    }
    public void Multiply()
    {
        Result = Num1 * Num2;
    }
    public void Divide()
    {
        Result = Num1 / Num2;
    }
    public void PrintResult()
    {
        Console.WriteLine(Result);
    }
}
