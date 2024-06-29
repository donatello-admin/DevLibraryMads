using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetOrderAll
{
    public class GetOrderAllQuery : IRequest<List<OrderDTO>>
    {
        public GetOrderAllQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
