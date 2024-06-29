using DevLibraryMads.Core.Enums;

namespace DevLibraryMads.Core.DTOs
{
    public class BookDTO
    {
        public BookDTO(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
