namespace CSharpBasics;
/// <summary>
/// Type conversion is of two types (Valued Datatypes)
/// 1. Implicit - Automatic (the conversion that does not result in any loss are converted
/// automatically.)
/// 2. Explicit - Manual (the conversion that has a chance of any loss are not converted 
/// automatically and needs to be converted manually)
/// </summary>
public class CH03_TypeConversion
{
    public static void Test()
    {
        ExplicitConversion();
    }
    public static void ImplicitConversion()
    {
        byte b = 255;       //8bit
        short s = b;        //16bit
        int i = s;          //32bit
        long l = i;         //64bit
        Int128 int128 = l;  //128bit

        float f = i;
        double d = i;
        decimal m = i;

        char c = 'a';       //'a' is 97 refer ASCII Chart
        i = c;              //int32
        l = c;              //long64
        int128 = c;         //Int128
    }
    public static void ExplicitConversion()
    {
        //This process requires casting/parsing
        //BE CAREFUL WHILE EXPLICIT CONVERSION AS RESULTS MAY 
        //BE UNPREDICTABLE
        Int128 int128 = 1;
        long l = (long)int128; //this will cast int128 into long
        int i = (int)l;
        short s = (short)i;
        byte b = (byte)s;

        ///following conversion is unpredictable as 
        ///8 bits from short(16bits) are copied into byte(8bit)
        s = 200;
        sbyte b1 = (sbyte)s;
        Console.WriteLine($"short {s} is converted into byte {b1}");

        float f = 4.9999f;
        i = (int)f;
        Console.WriteLine($"float {f} is converted into int {i}");

        i = 97;//be careful while conversion as number beyond capacity will give unpredictable results
        char c = (char)i;
        Console.WriteLine($"int {i} is converted into char {c}");
    }
}
