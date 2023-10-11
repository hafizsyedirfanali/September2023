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
        ImplicitConversion();
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

        char c = 'a';       //'a' is 97
        i = c;              //int32
        l = c;              //long64
        int128 = c;         //Int128
    }
}
