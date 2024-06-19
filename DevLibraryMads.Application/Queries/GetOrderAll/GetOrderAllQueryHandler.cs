using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetOrderAll
{
    public class GetOrderAllQueryHandler : IRequestHandler<GetOrderAllQuery, List<OrderDTOs>>
    {

        private readonly IOrderRepository _orderRepository;

        public GetOrderAllQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDTOs>> Handle(GetOrderAllQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            var orderDTOs = orders
                .Select(o => new OrderDTOs(o.NumPedVda, o.Client.FullName, o.Client.BirdthDate, o.Client.Email, o.Book.Title, o.Book.Description, o.Book.Author, o.CreatedAt, o.ReturnedAt, o.StatusOrder, o.ValueFined))
                .ToList();

            return orderDTOs;
        }
    }
}
