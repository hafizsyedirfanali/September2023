namespace OOPProject //Name of Project / Assembly
{
    /// <summary>
    /// ACCESS MODIFIERS
    /// </summary>
    public class CH08_Encapsulation// Class / TYPE  //this type is accessed in program.cs of csharpbasic assembly
    {
        /// <summary>
        /// A Type can only be either public or internal
        /// If it is made public then it will be accessible everywhere 
        /// i.e. within same assembly or from different assembly
        /// If it is made internal then it will be accessible from within the same assembly only.
        /// </summary>
        private class InnerClass//Class
        {
            ///A class within a class (TYPE) can be either public or internal or private or protected
            ///public - accessible everywhere
            ///internal - accessible within same assembly
            ///private - accessible within a class where it is defined.
            ///protected - will study after inheritance 
            ///
            int i = 100;//if access modifier is not specified then it is private by default.
            public int j = 100;// fields are not to be used as public member
            public string Name { get; set; }
            //similarly other members can be made public, private, protected or internal
            public class A
            {

            }
            private class B
            {

            }
            class C //private by default
            {

            }
        }
        public void Test()
        {
            InnerClass innerClass = new InnerClass();
            //innerClass.i = 100; //inaccessible due to its protection level (Private)
            innerClass.j = 100;
            innerClass.Name = "test";
            InnerClass.A a = new InnerClass.A();
            //InnerClass.B b = new InnerClass.B();//Inaccessible (private)
        }
    }
}
