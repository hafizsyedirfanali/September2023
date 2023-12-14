namespace OOPProject;
/// <summary>
/// Microsoft has provided three predefined delegates
/// 1. Action Delegate
/// 2. Func Delegate
/// 3. Predicate Delegate
/// </summary>
public class CH15_AdvanceDelegates
{
    //Create a custom delegate with three overloads in which first will take a input and does not return a value
    //second will take one input and return one value and third will take two inputs and return a value
    public class CustomDeletage
    {
        public delegate void MyDelegate<in T>(T arg);
        public delegate T2 MyDelegate<in T1, out T2>(T1 input);
        public delegate T3 MyDelegate<in T1, in T2, out T3>(T1 input1, T2 input2);
        public void Test()
        {
            MyDelegate<int> myDelegate = MyDelegateMethod;
            MyDelegate<int, string> myDelegate1 = MyDelegateMethod1;
            MyDelegate<int,int,string> myDelegate2 = MyDelegateMethod2;
        }
        public void MyDelegateMethod(int a)
        {

        }
        public string MyDelegateMethod1(int arg)
        {
            return "Hello";
        }
        public string MyDelegateMethod2(int arg1, int arg2)
        {
            return "Hello";
        }
    }
    public class PredicateDelegate
    {
        public void Test()
        {
            Predicate<int> predicate = PredicateMethod;
        }
        public bool PredicateMethod(int arg)
        {
            return false;
        }
    }
    public class FuncDelegate
    {
        /// <summary>
        /// Func delegate can keep reference of the methods that must return a value and can accept input parameters from 0 to 16
        /// </summary>
        public void Test()
        {
            Func<int> func1 = FuncMethod1;
            Func<int,int> func2 = FuncMethod2;//and so on
            Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, string> func17 = FuncMethod17;
        }
        public int FuncMethod1()
        {
            return 1;
        }
        public int FuncMethod2(int arg1)
        {
            return 1;
        }
        public string FuncMethod17(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8,
           int arg9, int arg10, int arg11, int arg12, int arg13, int arg14, int arg15, int arg16)
        {
            return "Hello";
        }
    }
    public class ActionDelegate
    {
        /// <summary>
        /// It can keep reference of a method/function that does not return a value and can take parameters from 1 to 16.
        /// </summary>
        public void Test()
        {
            //Declaration
            Action<int> action1 = ActionMethod1;
            Action<int,int> action2 = ActionMethod2;
            ///---
            Action<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int,int> action16 = ActionMethod16;
        }
        public void ActionMethod1(int arg)
        {

        }
        public void ActionMethod2(int arg1, int arg2)
        {

        }
        public void ActionMethod16(int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8,
            int arg9, int arg10, int arg11, int arg12, int arg13, int arg14, int arg15, int arg16)
        {

        }
    }
}
