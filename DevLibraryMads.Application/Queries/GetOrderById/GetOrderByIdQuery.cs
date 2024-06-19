using DevLibraryMads.Core.DTOs;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDTOs>
    {
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
