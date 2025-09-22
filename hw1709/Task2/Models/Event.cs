namespace Task2.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<EventParticipant> EventParticipants { get; set; }
    }
}
