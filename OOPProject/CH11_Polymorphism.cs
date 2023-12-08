namespace OOPProject;
/// <summary>
/// Polymorphism is referred as many faces of same object.
/// 1. Overloading
/// 2. Overriding
/// 3. Instantiation of Base class by Derived Class
/// </summary>

public class CH11_Polymorphism
{
  
    public void Test()
    {
        //Create instance of Base Class using Base Class Constructor
        BaseClass b1 = new BaseClass();
        //Create instance of Base Class using DerivedLevel1 Class Constructor
        BaseClass b2 = new DerivedLevel1Class();
        //Create instance of Base Class using DerivedLevel2 Class Constructor
        BaseClass b3 = new DerivedLevel2Class();
        //This is possible because the child class (derived class) constructor
        //calls its parent (base) class constructor

        //Calling parameterized constructor
        BaseClass b4 = new BaseClass(10);
        BaseClass b5 = new DerivedLevel1Class(10);
        BaseClass b6 = new DerivedLevel2Class(10);

    }
    public class BaseClass
    {
        public BaseClass()//Default Parameterless Constructor
        {
                
        }
        public BaseClass(int arg1)
        {
            
        }
    }
    public class DerivedLevel1Class : BaseClass
    {
        public DerivedLevel1Class()//Default Parameterless Constructor
        {
            
        }
        public DerivedLevel1Class(int arg1) : base(arg1)
        {
            
        }
    }
    public class DerivedLevel2Class : DerivedLevel1Class
    {
        public DerivedLevel2Class()//Default Parameterless Constructor
        {
            
        }
        public DerivedLevel2Class(int arg1) : base(arg1)
        {
            //We will use this pattern in ApplicationDbContext Class
        }
    }

    
}
