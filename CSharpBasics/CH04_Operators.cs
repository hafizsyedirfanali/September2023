namespace CSharpBasics;
/// <summary>
/// Operators are used to perform certain operations on the Operands/Literals.
/// There are various operators.
/// 1. Assignment
/// 2. Arithmatic
/// 3. Logical / Comparasion
/// 4. Shift
/// NOTE: These are Left Associative
/// </summary>
public class CH04_Operators
{

    public static void Test()
    {
        ShiftOperators();
    }
    public static void BooleanOperation()
    {
        //BitWiseAnding();
        BitWiseORing();
    }
    public static void ShiftOperators()
    {
        int i = 2; //010
        Console.WriteLine($"Right Shift by one gives {i>>1}");
        ///                       010    >>1    001  = 1
        Console.WriteLine($"Right Shift by two gives {i>>2}");
        ///                       010    >>2    000  = 0
        Console.WriteLine($"Left Shift by one gives {i<<1}");
        ///                       010    <<1    100  = 4
        Console.WriteLine($"Left Shift by two gives {i<<2}");
        ///                       010    <<2   1000  = 8
    }
    public static void BitWiseORing()
    {
        int a = 1; //01
        int b = 2; //10
        int c = 3; //11
        Console.WriteLine($"Bitwise ORing a | b is {a | b}");
        ///                                             01
        ///                                             10
        ///                                             ---
        ///                                             11 = 3
        Console.WriteLine($"Bitwise Anding a | c is {a | c}");
        ///                                             01
        ///                                             11
        ///                                             ----
        ///                                             11   = 3
        Console.WriteLine($"Bitwise Anding a | b | c is {a | b | c}");
        ///                                             01
        ///                                             10
        ///                                             11
        ///                                             ---
        ///                                             11   = 3
    }
    public static void BitWiseAnding()
    {
        int a = 1; //01
        int b = 2; //10
        int c = 3; //11
        Console.WriteLine($"Bitwise Anding a & b is {a & b}");
        ///                                             01
        ///                                             10
        ///                                             ---
        ///                                             00 = 0
        Console.WriteLine($"Bitwise Anding a & c is {a & c}");
        ///                                             01
        ///                                             11
        ///                                             ----
        ///                                             01   = 1
        Console.WriteLine($"Bitwise Anding a & b & c is {a & b & c}");                                             
        ///                                             01
        ///                                             10
        ///                                             11
        ///                                             ---
        ///                                             00   = 0
    }
    public static void Logical_ComparasionOperators()
    {
        //Logical or Comparasion operators are AND OR NOT
        //Anding &&
        Console.WriteLine("ANDING");
        Console.WriteLine($"True and True is {true && true}");
        Console.WriteLine($"True and False is {true && false}");
        Console.WriteLine($"False and True is {false && true}");
        Console.WriteLine($"False and False is {false && false}");
        //ORing ||
        Console.WriteLine("ORing");
        Console.WriteLine($"True or True is {true || true}");
        Console.WriteLine($"True or False is {true || false}");
        Console.WriteLine($"False or True is {false || true}");
        Console.WriteLine($"False or False is {false || false}");
        //NOT !
        Console.WriteLine("NOT Operation");
        Console.WriteLine($"not of True is {!true}");
        Console.WriteLine($"not of False is {!false}");
        //Less than
        Console.WriteLine("Enter marks");
        int marks = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(marks < 35);
        //Less than and equal to 
        Console.WriteLine(marks <= 35);
        //Greater than
        Console.WriteLine(marks > 35);
        //Greater than and equal to 
        Console.WriteLine(marks >= 35);
        //equal to
        Console.WriteLine(marks == 35);
        //not equal to
        Console.WriteLine(marks != 35);
    }
    public static void ArithmaticOperators()
    {
        //Addition '+'
        int sum = 2 + 3;
        //Subtraction -
        int difference = 3 - 2;
        //Multiplication/Times/Product *
        int product = 3 * 2;
        //Division for Getting Quotient /
        int quotient = 3 / 2;
        //Division for Getting Remainder %
        int remainder = 3 % 2;
    }
    public static void AssignmentOperators()
    {
        ///Assignment operators are used to assign values or results from right to left
        int age = 10;//here = is assignment operator which assign value from Right to Left
        //for performing arithmtic operation with assignment
        //for example age = age + 1
        age += 1;//age = age + 1 :: Increment
        age -= 1;//age = age - 1 :: Decrement
        age *= 2; //age = age * 2;
        //age = age /(divide by) 3 and result is quotient
        age = 20;//if age is 20 then quotient will be 6
        age /= 3;//age = age / 3; age will have value = 6
        age = 10;
        //age = age (divide by) 3 then remainder will be 1
        age %= 3; //age = age % 3;
        ///other operators can be written in the same format
        //For Left shift
        age <<= 1; //it will left shift the value by one and store in age
        age &= 1;//it will AND bitwise and store the result in age
    }
    ///Homework:
    ///Compare the following 
    ///T & T & F
    ///T & F | T
    ///T | F & T
    ///T & (F | T) | T
    ///F & (T | T | F) | T
}
