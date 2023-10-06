namespace CSharpBasics;
/// <summary>
/// Data Types are the types of data that are stored in RAM memory
/// Basic Data types are 
/// 1. integer (signed & unsigned)
/// 2. real/floating (signed & unsigned)
/// 3. character
/// 4. boolean
/// These are called VALUED Data Type.
/// These are stored in Stack memory and are removed at the end of scope '}'
/// We have another datatype called REFERENCED Data Type
/// </summary>
public class CH02_DataTypes
{
    public static void Test()
    {
        IntegerDataType();
    }
    public static void NumberSystem()
    {
        ///There are basically four number system
        ///1. Decimal
        ///2. Binary
        ///3. Octal
        ///4. Hexadecimal
        ///In decimal numbers available are 0,1,2,3,4,5,6,7,8,9
        ///In binary numbers available are 0,1
        ///Binary(2 bits i.e. 0 & 1)
        ///000  0
        ///001  1
        ///010  2
        ///011  3
        ///100  4
        ///101  5
        ///110  6
        ///111  7
        ///If i want to have both signs (+ & -) then divide the capacity into two
        ///for three bits the capacity is 8. for two signs it should be divided by two
        ///for - : 8/2 = 4 (i.e. -4,-3,-2,-1)
        ///for + : 8/2 = 4 (i.e. 3,2,1,0)
        ///therefore capacity will be expressed as (-4 to 3)
        ///This type is called SIGNED because it has both signs (+ & -)
        ///and the type which has only one sign (i.e. +) is called UNSIGNED
        ///Decimal = 2^(binary bits)
        ///2^3 = 8
        ///2^4 = 16
        ///Unsigned byte/Byte Type : 2^8 = 256 (8bit)
        ///Signed byte Type        : 2^8 = 256/2 = 128 (-128 to 127)
        ///Unsigned short/Int16 Type : 2^16 = 65536
        ///Signed Short Type         : 2^16 = 65536/2 = (-32768 to 32767)
        ///Unsigned int/Int32 Type : 2^32 = 4294967296
        ///Signed int Type         : 2^32 = 4294967296/2 = (-2147483648 to 2147483647)
        ///Unsigned long/Int64 Type : 2^64 = 18446744073709551616
        ///Signed long              : 2^64 = 18446744073709551616/2 = (-9223372036854775808 to 9223372036854775807)
        ///Unsigned Int128 2^128 = 340282366920938463463374607431768211456
        ///Signed Int128 2^128/2 = (-170141183460469231731687303715884105728 to 170141183460469231731687303715884105727)


    }
    public static void IntegerDataType()
    {
        Byte ub = 255; 
        ub = 1;
        byte ubbyte = 255;
        SByte b = -128; b = 127;
        
        UInt16 ui16 = 65535;//short
        ushort ui16short = 65535;
        Int16 i16 = -32768; i16 = 32767;
        //Homework: write variables with max capacity for following types: int32, int 64, int128
        UInt32 ui32 = 4294967295;
        uint ui32int = 4294967295;
        Int32 si32 = -2147483648; si32 = 2147483647;
        UInt64 ui64 = 18446744073709551615;
        ulong ui64long = 18446744073709551615;
        Int64 si64 = -9223372036854775808; si64 = 9223372036854775807;
        //UInt128 ui128 = 340282366920938463463374607431768211455;
        //Int128 si128 = -170141183460469231731687303715884105728; b = 170141183460469231731687303715884105727;

    }
    public static void FloatingDataType()
    {
        //We have three data types in this category float, double and decimal
        //1. float 4bytes
        float f = 1.1f;//in float a number 1.1 to be appended by f
        //2. double 8bytes
        double d = 1.1d;//in double a number 1.1 may be appended by d
        double d1 = 1.1;
        //3. decimal 16bytes
        decimal m = 1.1m;//in decimal a number 1.1 to be appended by m
    }
    public static void CharacterDataType()
    {
        //This data type is used to store a character from the list of ASCII characters
        char c = '1';//here 1 as a char will be saved as decimal 49. Refer chart
    }
    public static void BooleanDataType()
    {
        //
        Boolean b = true;//It will be saved as 1
        bool b1 = false;//It will be saved as 0
    }

    public static void ReferencedDataType()
    {
        //String data type : Array of Character 
        // if i want to save a sentence "hello from .net class"
        string s = "hello from .net class";
        string greet = "Hello";
        //there are some more referenced data types other than string
        //for example Class object, interfaces, etc
    }
}

