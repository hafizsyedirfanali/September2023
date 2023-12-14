namespace OOPProject;
/// <summary>
/// Generics are the classes or functions that facilitates user to pass the type.
/// It also facilitate code decoupling
/// </summary>
public class CH16_Generics
{
    public void Test()
    {
        Student<int> student = new Student<int>();
        Student<float> student1 = new Student<float>();
        Student<string> student2 = new Student<string>();
        Teacher<int, int, int> teacher = new Teacher<int, int, int>();
        Teacher<int, float, int> teacher1 = new Teacher<int, float, int>();
        Teacher<int, float, string> teacher2 = new Teacher<int, float, string>();
        GenericFunctionClass g = new GenericFunctionClass();
        g.GenericFunction<int>(10);
        g.GenericFunction<float>(10.3f);
        g.GenericFunction<string>("hello");

    }
    //following is the generic class that accept T type
    public class Student<T>
    {
        public int IntProperty { get; set; }
        public T GenericProperty1 { get; set; }
        public T GenericProperty2 { get; set; }
        public T GenericProperty3 { get; set; }
        public T GenericProperty4 { get; set; }
        //we can use the type T in all the other members
    }
    public class Teacher<T1,T2,T3>//T1, T2 and T3 are generic parameters that expect type
    {
        public int IntProperty { get; set; }
        public T1 GenericProperty1 { get; set; }
        public T2 GenericProperty2 { get; set; }
        public T3 GenericProperty3 { get; set; }
    }
    public class GenericFunctionClass
    {
        public P GenericFunction<P>(P arg)
        {
            P obj;
            return arg;
        }
    }
}
