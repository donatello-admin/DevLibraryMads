using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetBookAll
{
    public class GetBookAllQueryHandler : IRequestHandler<GetBookAllQuery, List<BookDTO>>
    {

        private readonly IBookRepository _bookRepository;

        public GetBookAllQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDTO>> Handle(GetBookAllQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();

            var bookDTOs = books
                .Select(b => new BookDTO(b.Title, b.Description, b.Author))
                .ToList();

            return bookDTOs;
        }
    }
}
