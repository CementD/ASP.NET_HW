namespace LibraryExam.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string ISBN { get; set; } = "";
        public int CopiesAvailable { get; set; }
    }
}
