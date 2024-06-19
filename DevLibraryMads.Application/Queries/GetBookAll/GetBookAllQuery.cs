﻿using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetBookAll
{
    public class GetBookAllQuery : IRequest<List<BookDTOs>>
    {
        public GetBookAllQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
