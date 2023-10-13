namespace CSharpBasics;
/// <summary>
/// Type conversion is of two types (Valued Datatypes)
/// 1. Implicit - Automatic (the conversion that does not result in any loss are converted
/// automatically.)
/// 2. Explicit - Manual (the conversion that has a chance of any loss are not converted 
/// automatically and needs to be converted manually)
/// 3. Using Convert Class
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
        //byte byte1 = 1;
        //bool b2 = (bool)byte1;
        //for boolean conversion we have to use Convert class

    }
    public static void ConversionUsingConvertClass()
    {
        string str = "";

        //To Integer
        //1) to Byte
        str = "1";
        byte by = Convert.ToByte(str);
        //2) to short
        short s = Convert.ToInt16(str);
        //3) to int
        int i = Convert.ToInt32(str);
        //4) to long
        long l = Convert.ToInt64(str);
        //5) to Int128
        //Int128 int128 = Convert.ToInt128("str");//not yet ready from Microsoft

        //To Floating/fractional numbers
        str = "1.2";
        float f = Convert.ToSingle(str);//float
        double d = Convert.ToDouble(str);
        decimal m = Convert.ToDecimal(str);

        //To Character
        str = "a";
        char c = Convert.ToChar(str);

        //To Boolean
        //from string to bool
        str = "true";
        bool b = Convert.ToBoolean(str);
        //from int to bool
        i = 10;
        b = Convert.ToBoolean(i);
    }
    public static void ConvertUsingParse()
    {
        string str = "";
        //To Integer
        str = "12";
        byte b = byte.Parse(str);
        //To Floating

        //To Char

        //To boolean
    }
    //Next is tryparse
}
