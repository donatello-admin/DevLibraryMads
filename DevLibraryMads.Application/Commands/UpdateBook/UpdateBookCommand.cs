using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<int>
    {
        public UpdateBookCommand(int id)
        {
            Id = id;

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
