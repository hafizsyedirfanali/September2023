namespace CSharpBasics;
/// <summary>
/// DRY is a principle in coding. it means Don't Repeat Yourself.
/// Loops are used to follow DRY principle. They are used to repeat the set of instructions
/// number of times based on some condition. Each repeatition is called iteration.
/// In loops we can use continue and break keywords to skip the iteration or break the further iterations.
/// We have different types of loops.
/// 1. while loop
/// 2. do while loop
/// 3. for loop
/// 4. foreach loop
/// while, do-while and for loops require 
/// 1) initialization of counter also called loop variable, 
/// 2) increment/decrement, 
/// 3) condition - Its a statement which gives boolean result or a function that returns boolean result
/// these three loops 1,2 & 3 run or iterate until condition is true. 
/// it stops looping when condition is false.
/// </summary>
public class CH06_Loops
{
    public void Test()
    {
        TestInfiniteWhile();
    }
    public void TestWhile()
    {
        //To print the Hello 10 number of times
        int counter = 0; //initialization
        while(counter < 10)//condition
        {
            Console.WriteLine($"{counter+1} Hello");
            counter++;//increment
        }
        Console.WriteLine("End of loop");
    }
    public void TestInfiniteWhile()
    {
        while (true)
        {
            Console.WriteLine("Inifinte loop");
        }
    }
    public void TestDoWhile()
    {
        ///Do while loop is a special loop as it runs or iterates once even if condition fails.
        int counter = 0;//initialization
        do
        {
            Console.WriteLine($"{counter + 1} Hello");
            counter++;//increment
        }
        while (counter < 10);//condition
    }
    public void TestFor()
    {
        //it is special as its variable life is only upto end of loop.
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i+1} Hello");
        }
    }
    public void TestForWithContinue()
    {
        //continue is a keyword which is used to skip the current iteration
        for (int i = 0; i < 10; i++)
        {
            if(i % 2 != 0) continue;//Skipping odd numbers
            Console.WriteLine($"{i} Hello");
        }
    }
    public void TestForWithBreak()
    {
        for(int i = 0;i < 10; i++)
        {
            if (i == 6) break;
            Console.WriteLine($"{i} Hello");
        }
    }
    public void TestInfiniteFor()
    {
        for (;true;)
        {
            Console.WriteLine("Infinite loop");
        }
    }
    public void TestForEach()
    {
        //it does not require initialization, condition and increment/decrement.
        //It runs over the collection till it ends.
        int[] rollNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        foreach (int rollNo in rollNumbers)
        {
            //if (rollNo == 3) break;//we can use break and continue here also
            Console.WriteLine($"Roll No:{rollNo}");
        }

        string[] names = new string[] { "mehvish", "suboor", "adil", "shahnawaz", "adnan", "maaz", "rizwan" };
        foreach (string name in names)
        {
            Console.WriteLine($"Name:{name}");
        }
        char[] chars = new char[] { 's', 'u', 'b', 'o', 'o', 'r' };
        foreach(char ch in chars)
        {
            //Console.WriteLine($"Character : {ch}");
            Console.Write(ch);
        }
    }
}
