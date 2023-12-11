namespace OOPProject;
/// <summary>
/// Overriding is the changing the way of operation.
/// We can use it during inheritance. If parent class has a function then 
/// child class can either use the parent function or override it.
/// </summary>
public class CH12_Overriding
{
    public void Test()
    {
        DerivedClass d = new DerivedClass();
        var result = d.Decrement(10);
        Console.WriteLine($"New Value is {result}");
    }
    public class BaseClass
    {
        public int Increment(int x)
        {
            var result = x + 1;
            return result;
        }
        public virtual int Decrement(int x)//A function is made virtual to facilitate overriding
        {
            var result = x - 1;
            return result;
        }
    }
    public class DerivedClass : BaseClass
    {
        public new int Increment(int x)
        {
            x = x + 1;
            return x;
        }
        public override int Decrement(int x)//This is overriding function
        {
            return x - 1;//we can override the logic of base class
           // return base.Decrement(x);//we can use the logic of base class
        }
    }
}
