using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDTO>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
