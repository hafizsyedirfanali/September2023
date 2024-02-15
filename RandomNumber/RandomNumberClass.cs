namespace RandomNumber
{
    public class RandomNumberClass
    {
        public static int GetRandomNumber()
        {
            var random = new Random();
            return random.Next();
        }
    }
}
