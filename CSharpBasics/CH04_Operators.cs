namespace CSharpBasics;
/// <summary>
/// Operators are used to perform certain operations on the Operands/Literals.
/// There are various operators.
/// 1. Assignment
/// 2. Arithmatic
/// 3. Logical
/// 4. Comparasion
/// 5. Shift
/// </summary>
public class CH04_Operators
{
    public static void Test()
    {
        AssignmentOperators();
    }
    public static void LogicalOperators()
    {
        //Logical operators are AND OR NOT
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
    }
}
