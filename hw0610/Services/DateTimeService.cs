namespace hw0610.Services
{
    public class DateTimeService : IDateTimeService
    {
        public string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("dd.MM.yyyy H:mm");
        }
    }
}
