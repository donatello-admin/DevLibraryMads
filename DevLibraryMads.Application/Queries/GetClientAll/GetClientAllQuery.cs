using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetClientAll
{
    public class GetClientAllQuery : IRequest<List<ClientDTOs>>
    {
        public GetClientAllQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }

    }
}
