using System.Threading.Channels;

namespace CSharpBasics;
/// <summary>
/// Conditional Statements are used to execute set of statements based on condition
/// They are,
/// 1. If-Else (If Else, if else ladder, if else nested)
/// 2. Switch case
/// 3. Ternary ? :
/// 4. Null Coalsing operator ??
/// 5. Null forgiving operator !
/// </summary>
public class CH05_ConditionalStatements
{
    public void Test()
    {
        TestNullCoalsing();
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
    public void TestIfElse2()//Else if Ladder
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
        //it has a drawback, that its worst case complexity is very high as compared to best case complexity
        //in the above example best case complexity is one unit and worst case complexity is six units, when all the conditions are false.
        //in such cases we use switch
        //Complexity is O(n), where n is number of conditions
    }
    public void TestIfElse3()//Nested If Else
    {
        Console.WriteLine("Enter marks");
        int marks = Convert.ToInt32(Console.ReadLine());
        //Outer if else will filter valid marks
        if(marks>=0 && marks <= 100)
        {
            if(marks > 35)
            {
                if(marks < 60)
                {
                    Console.WriteLine("Second Class");
                }
                else
                {
                    if(marks < 75)
                    {
                        Console.WriteLine("First Class");
                    }
                    else
                    {
                        Console.WriteLine("Distinction");
                    }
                }
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
        else
        {
            Console.WriteLine("Invalid marks");
        }
        //In this example the worst case (Big O) complexity is 4 unit.
        //Complexity O(log_2 n) = O(ln n)
    }
    public void TestSwitch()
    {
        Console.WriteLine("Enter code");
        int code = Convert.ToInt32(Console.ReadLine());
        switch(code)
        {
            case 1: Console.WriteLine("Welcome");
                break;
            case 2: Console.WriteLine("Namaste");
                break;
            case 3: Console.WriteLine("Salaam");
                break;
            default: Console.WriteLine("Invalid code");
                break;
        }
        //its complexity is one unit time (constant complexity)
        //Complexity = O(1)
    }

    public void TestTernary()//Ternary operator ? :
    {
        Console.WriteLine("Enter marks");
        int marks = Convert.ToInt32(Console.ReadLine());
        string status = marks > 35 ? "Pass" : "Fail";
        //string status = true ? "Pass" : "Fail";
        //string status = "Pass";
        Console.WriteLine(status);
        //Alternatively, 
        Console.WriteLine(marks>35?"Pass":"Fail");
        //Nested
        string status1 = marks > 35 ? (marks > 60? (marks > 75? "Distinction":"First Class"):"Second Class") : "Fail";
        //Nested is NOT RECOMMENDED
        //Complexity = O(log_2 n)
    }
    public void TestNullCoalsing()
    {
        string? status = null;
        Console.WriteLine("Enter marks");
        bool isSuccess = int.TryParse(Console.ReadLine(), out int marks);
        if (isSuccess)
        {
            if(marks > 35)
            {
                status = "Pass";
            }
            else
            {
                status = "Fail";
            }
        }
        Console.WriteLine(status ?? "Invalid Marks");
        //?? means take the value from status i.e. LHS if it is not null otherwise take value from RHS
        //same can be observed using ternary but null coalsing is best
        Console.WriteLine(status != null ? status : "Invalid Marks");
    }
    public void TestNullForgiving()
    {
        string status = Console.ReadLine() ?? "invalid";
        string status1 = Console.ReadLine()!;//ignore the warning, i take responsibility that null will never come
        //using null forgiving is risky. use only if you are sure that null will never come.
        //it is used to hide the warning

    }
}
