namespace OOPProject;
/// <summary>
/// Abstraction is the process of hiding data or methods and showing only essential information (defination) to the user.
/// We use abstract classes or interfaces to achieve abstraction 
/// means to show the defination and to hide the implementation.
/// </summary>
public class CH09_Abstraction
{
    public class UsingAbstractClasses
    {
        public void Test()
        {
            Implementation implementation = new Implementation();
            int result = implementation.Add(10, 20);
        }
        public abstract class Defination
        {
            public abstract int Count { get; set; }
            public abstract int Add(int x, int y);
          
        }
        public class Implementation : Defination //Using : we say that Implementation class will implement the Defination Class abstract methods
        {
            private int count;
            public override int Count
            {
                get
                {
                    return count;
                }
                set
                {
                    count = value;
                }
            }
            public override int Add(int x, int y)
            {
                return x + y;
            }
        }
    }
    public class UsingInterfaces
    {
        public interface IDefination
        {
            public int Count { get; set; }
            public int Add(int x, int y);
        }
        public class Implementation : IDefination
        {
            private int count;
            public int Count 
            { 
                get
                {
                    return count;
                }
                set
                {
                    count = value;
                }
            }

            public int Add(int x, int y)
            {
                return x + y;
            }
        }
    }
}
