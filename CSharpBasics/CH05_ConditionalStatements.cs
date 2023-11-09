namespace CSharpBasics;
/// <summary>
/// Conditional Statements are used to execute set of statements based on condition
/// They are,
/// 1. If-Else (If Else, if else ladder, if else nested)
/// 2. Switch case
/// 3. Ternary
/// 4. Null Coalsing operator
/// </summary>
public class CH05_ConditionalStatements
{
    public void Test()
    {
        TestIfElse2();
    }
    //If - else
    public void TestIfElse1()
    {
        //if(<condition>) { set of instruction to be executed if condition is satisfied } else { set of instructions to be executed if condition is not satisfied }
        //<condition> can be either true or false
        Console.WriteLine("enter two values in number format");
        int value1 = Convert.ToInt32(Console.ReadLine());
        int value2 = Convert.ToInt32(Console.ReadLine());
        if(value1 > value2)
        {
            Console.WriteLine("First value is greater");
        }
        else
        {
            Console.WriteLine("Second value is greater");
        }
    }
    public void TestIfElse2()
    {
        Console.WriteLine("Enter marks");
        int marks = Convert.ToInt32(Console.ReadLine());
        if(marks < 0)
        {
            Console.WriteLine("Invalid marks");
        }
        else if(marks < 35)
        {
            Console.WriteLine("Fail");
        }
        else if(marks < 60)
        {
            Console.WriteLine("Second class");
        }
        else if(marks < 75)
        {
            Console.WriteLine("First Class");
        }
        else if(marks <= 100)
        {
            Console.WriteLine("Distinction");
        }
        else
        {
            Console.WriteLine("Invalid marks");
        }
        //it has a drawback
    }
}
