using MediatR;

namespace DevLibraryMads.Application.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public CreateBookCommand(string title, string description, string author)
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
