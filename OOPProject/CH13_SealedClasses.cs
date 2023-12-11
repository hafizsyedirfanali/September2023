namespace OOPProject;
/// <summary>
/// Sealed classes are resticted from inheritance
/// </summary>
public class CH13_SealedClasses
{
    public sealed class BaseClass
    {

    }
    public class DerivedClass //: BaseClass
    {
        //We cannot derive a class from a sealed class.
    }
}
