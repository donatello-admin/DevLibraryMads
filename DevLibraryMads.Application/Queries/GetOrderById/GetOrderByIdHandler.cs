using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {

        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            var orderDTOs = new OrderDTO(order.NumPedVda, order.Client.FullName, order.Client.BirdthDate, order.Client.Email, order.Book.Title, order.Book.Description, order.Book.Author, order.CreatedAt, order.ReturnedAt, order.StatusOrder,order.ValueFined, order.StatusPayment);

            return orderDTOs;
        }
    }
}
