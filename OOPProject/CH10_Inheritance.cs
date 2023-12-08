namespace OOPProject;
/// <summary>
/// Inheritance is a fundamental concept of object-oriented programming 
/// that allows us to define a new class based on an existing class.
/// The new class, which is inherited from old class is called derived class (child class) and
/// the old class is called base class (parent class).
/// </summary>
public class CH10_Inheritance
{
    public void Test()
    {
        BaseClass b = new BaseClass();
        b.Name = "Test";
        b.Age = 1;
        b.Email = "Test@test.com";
        b.PrintName();
        DerivedClass d = new DerivedClass();
        d.Age = 2;
        d.Name = "Test";
        d.Email = "a@a.com";
        d.PrintName();
    }
    public class BaseClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public void PrintName()
        {
            Console.WriteLine(Name); ;
        }
    }
    public class DerivedClass : BaseClass
    {
        //All the members of base class will be inherited here
    }

    public class TypesOfInheritance
    {
        ///Types of Inheritance
        ///1. Single Inheritance
        ///2. Multilevel Inheritance
        ///3. Hierarchical Inheritance
        ///4. Hybrid Inheritance
        ///5. Multiple Inheritance (Invalid in C#, but can be observed using Interfaces)
        ///



        public class SingleInheritance
        {
            public class ParentClass
            {
                //Base Class
            }
            public class ChildClass : ParentClass
            {
                //Derived Class (derived from Parent Class)
            }
        }
        public class MultilevelInheritance
        {
            public class ParentClass
            {
                //Base Class
            }
            public class ChildLevel1Class : ParentClass
            {
                //Derived from Parent Class
            }
            public class ChildLevel2Class : ChildLevel1Class
            {
                //Derived from ChildLevel1Class
            }
        }
        public class HierarchicalInheritance
        {
            public class ParentClass 
            {
                //Base class
            }
            public class Child1Class : ParentClass
            {
                //Derived from parent class
            }
            public class Child2Class : ParentClass
            {
                //Derived from parent class
            }
            public class Child3Class : ParentClass
            {
                //Derived from parent class
            }
        }
        public class HybridInheritance
        {
            public class ParentClass
            {
                //Base Class
            }
            public class Child1Class : ParentClass
            {
                //Derived from Parent Class
            }
            public class Child2Class : ParentClass
            {
                //Derived from Parent Class
            }
            public class ChildClass : Child1Class
            {
                //Derived from Child1 class
            }
        }
        public class MultipleInheritance
        {
            public interface IParent1
            {
                
            }
            public interface IParent2
            {

            }
            public interface IParent3
            {

            }
            public class ChildClass : IParent1, IParent2, IParent3
            {

            }
        }
    }

}
