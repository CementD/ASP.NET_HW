namespace hw0610.Services
{
    public class RandomNumberService : IRandomNumberService
    {
        private static readonly Random _random = new Random();
        public int GetRandomNumber()
        {
            return _random.Next(1, 101);
        }
    }
}
