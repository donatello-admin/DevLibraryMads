using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetOrderAll
{
    public class GetOrderAllQueryHandler : IRequestHandler<GetOrderAllQuery, List<OrderDTO>>
    {

        private readonly IOrderRepository _orderRepository;

        public GetOrderAllQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDTO>> Handle(GetOrderAllQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            var orderDTOs = orders
                .Select(o => new OrderDTO(o.NumPedVda, o.Client.FullName, o.Client.BirdthDate, o.Client.Email, o.Book.Title, o.Book.Description, o.Book.Author, o.CreatedAt, o.ReturnedAt, o.StatusOrder, o.ValueFined, o.StatusPayment))
                .ToList();

            return orderDTOs;
        }
    }
}
