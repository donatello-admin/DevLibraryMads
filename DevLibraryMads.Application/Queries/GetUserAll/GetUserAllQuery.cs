﻿using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetUserAll
{
    public class GetUserAllQuery : IRequest<List<UserDTO>>
    {
        public GetUserAllQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
