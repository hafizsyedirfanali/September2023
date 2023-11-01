namespace OOPProject
{
    /// <summary>
    /// use ctor as code snippet of constructor
    /// Constructors are the methods that have
    /// 1. Name indentical to the class
    /// 2. It does not return any value
    /// 3. It is always automatically called at the time of Class Object Creation (Instantiation)
    /// Instantiation is a process of creating class instance
    /// 4. "new" keyword is used for Instantiation
    /// 5. whenever we create a new class a constructor is
    /// always created automatically which remains hidden. This constructor is
    /// called as default constructor. A default constructor is parameterless
    /// 6. we can override the default constructor.
    /// 7. we can overload the class constructors with different signatures.
    /// </summary>
    public class CH04_Constructors
    {
        public void Test()
        {
            //following line is instantiation of Student class using new keyword
            Student student = new Student();//in this statement Student() is constructor
            
            Teacher teacher = new Teacher();

            Mobile mobile = new Mobile("Hello world");

            Laptop laptop = new Laptop("ASUS",50000,true);

            Desktop desktop1 = new Desktop();
            Desktop desktop2 = new Desktop("ASUS");
            Desktop desktop3 = new Desktop(40000,"ASUS");
            Desktop desktop4 = new Desktop("ASUS", 40000);
            Desktop desktop5 = new Desktop(40000,"ASUS","Intel");
        }
        //The following student class has a constructor with name Student
        //but it is hidden
        public class Student
        {

        }
        //the following Teacher class shows overriding the default constructor
        //which is parameterless
        public class Teacher
        {
            //we have overridden the default hidden constructor
            public Teacher()
            {

            }
        }

        //the following class shows parameterized constructor
        public class Mobile
        {
            /// <summary>
            /// This constructor will create class instance
            /// This will get a string parameter 
            /// This will print the message
            /// </summary>
            public Mobile(string message)
            {
                Console.WriteLine(message);
            }
        }

        //Following class will have constructor will multiple parameters
        public class Laptop
        {
            public Laptop(string modelName, int price, bool isAvailable)
            {
                Console.WriteLine($"Model name: {modelName}");
                Console.WriteLine($"Price: {price}");
                Console.WriteLine($"Is Available?: {isAvailable}");
            }
        }
        //Following class has multiple constructors (Overloading)
        public class Desktop
        {
            //1. Parameterless default constructor
            public Desktop()
            {
                
            }
            //2. Single parameter constructor
            public Desktop(string modelName)
            {

            }
            //3. Two parameter constructor
            public Desktop(string modelName, int price)
            {

            }
            //4. Two parameter constructor
            public Desktop(int price, string modelName)
            {

            }
            //5. Three parameter constuctor
            public Desktop(int price, string modelName, string processor)
            {

            }
        }
    }
}
