namespace RandomNumber
{
    /// <summary>
    /// This project is referred in MVC Project in Home Controller in index action.
    /// this shows you how to create a separate class library project and add reference
    /// to it and use it in another project.
    /// </summary>
    public class RandomNumberClass
    {
        public static int GetRandomNumber()
        {
            var random = new Random();
            return random.Next();
        }
    }
}
