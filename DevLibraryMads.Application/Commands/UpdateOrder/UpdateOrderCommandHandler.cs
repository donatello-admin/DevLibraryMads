using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            DateTime dataNull = Convert.ToDateTime("0001-01-01 00:00:00.0000000");

            if (order.ReturnedAt != dataNull)
                return order.Id;

            var orderDTOs = new Order(order.NumPedVda, order.Id_Client, order.Id_Book,order.ValueFined);

            orderDTOs.ValueFined = orderDTOs.IsFined(order.CreatedAt, request.ReturnedAt);
            orderDTOs.ReturnedAt = request.ReturnedAt;

            await _orderRepository.UpdateAsync(orderDTOs);

            return order.Id;


        }
    }
}
