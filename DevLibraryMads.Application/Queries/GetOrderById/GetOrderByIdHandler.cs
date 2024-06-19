using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTOs>
    {

        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTOs> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            var orderDTOs = new OrderDTOs(order.NumPedVda, order.Client.FullName, order.Client.BirdthDate, order.Client.Email, order.Book.Title, order.Book.Description, order.Book.Author, order.CreatedAt, order.ReturnedAt, order.StatusOrder);

            return orderDTOs;
        }
    }
}
