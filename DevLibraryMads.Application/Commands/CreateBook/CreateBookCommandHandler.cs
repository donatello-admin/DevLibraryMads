﻿using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Description, request.Author);

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book.Id;
        }
    }
}
