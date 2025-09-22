namespace Task2.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<EventParticipant> EventParticipants { get; set; }
    }
}
