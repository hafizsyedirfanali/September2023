using System.ComponentModel.DataAnnotations;

namespace OOPProject;
/// <summary>
/// A method can be called by passing a value or a reference.
/// where a reference is an address of a variable or object.
/// the variable that holds the address is called reference variable or reference object.
/// we have three keywords for calling with reference i.e. 'in', 'out', and 'ref'.
/// 1. 'in' keyword specifies that the called function can only read the value from reference. With this passed reference variable must be assigned value before calling.
/// 2. 'out' keyword specifies that the called function must write the value to the reference. With this passed reference variable may or may not be assigned value before calling.
/// 3. 'ref' keyword specifies that the called function can read the value from and write the value to the reference.With this passed reference variable must be assigned value before calling.
/// 
/// We can call a function using a reference variable also
/// </summary>
public class CH07_CallByReference
{
    public void Test()
    {
        TestReferenceVariable2();
       // TestReferenceKeywords();
    }

    public void TestRefernceVariable()
    {
        Student student = new Student();
        AddStudentDetails(student);
        Console.WriteLine($"Student Id is {student.Id}");
        Console.WriteLine($"Student Name is {student.Name}");
        Console.WriteLine($"Student Address is {student.Address}");
    }
    public void TestReferenceVariable2()
    {
        //Task: Copy Student1 data to Student2
        Student student1 = new Student() { Id = 1, Name = "Irfan", Address = "Nagpur"};
        Student student2 = new Student();
        CopyStudentData(student1 , student2);
        Console.WriteLine($"Student Id is {student2.Id}");
        Console.WriteLine($"Student Name is {student2.Name}");
        Console.WriteLine($"Student Address is {student2.Address}");
    }
    public void TestReferenceVariable3()
    {
        Student student = new Student();
        int id = 10; string name = "suboor"; string address = "Nagpur";
        AddDataToStudent(student, in id, in name, in address);
    }
    public void TestReferenceKeywords()
    {
        int a = 30; int b = 20;
        int result = AddByValue(a, b);

        AddByReference(in a, in b, out result);//This call will send address of a, b & result variables
        SubtractByReference(ref a, ref b, ref result);
        int a1;
        a1 = 1;
        AddByReference(in a1, in b, out int result1);

        int b1;
        b1 = 1;
        SubtractByReference(ref a, ref b1, ref result);
    }
    public int AddByValue(int a, int b)//This is an example of call by value
    {
        return a + b;
    }
    //Example1 : Call by reference using in & out keywords
    public void AddByReference(in int a, in int b, out int result)
        //here a will hold the address of variable a in test method, similar is the case of b and result
        //the variables marked with "in" keyword can read the incoming value but cannot write,
        //the variable marked with "out" keyword must write the value before leaving the method
    {
        result = a + b + 10;
    }

    //Example2 : Call by reference using ref keyword
    //this ref keyword allows both reading and writing
    public void SubtractByReference(ref int a, ref int b, ref int result)
    {
        a += 1;
        b += 1;
        result = a - b;
    }

    //We learnt use of out keyword in parsing/casting chapter CH03_TypeConversion in CSharpBasics

    public void AddStudentDetails(Student std)
    {
        std.Id = 10;
        std.Name = "Adil";
        std.Address = "Nagpur";
    }
    public void CopyStudentData(Student sourceStudent, Student destStudent)
    {
        destStudent.Id = sourceStudent.Id;
        destStudent.Name = sourceStudent.Name;
        destStudent.Address = sourceStudent.Address;
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    //Task create a method AddDataToStudent and pass Student object, id, name, address to it
    //add this data to student object
    public void AddDataToStudent(Student std,in int id, in string name, in string address)
    {
        std.Id = id;
        std.Name = name;
        std.Address = address;
    }
}   
