using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.NumPedVda, request.Id_Client, request.Id_Book,request.ValueFined);

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
