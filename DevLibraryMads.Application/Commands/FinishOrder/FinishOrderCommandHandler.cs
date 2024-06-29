using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Repositories;
using DevLibraryMads.Core.Services;
using MediatR;

namespace DevLibraryMads.Application.Commands.FinishOrder
{
    public class FinishOrderCommandHandler : IRequestHandler<FinishOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentsService _paymentsService;

        public FinishOrderCommandHandler(IOrderRepository orderRepository, IPaymentsService paymentsService)
        {
            _orderRepository = orderRepository;
            _paymentsService = paymentsService;
        }

        public async Task<bool> Handle(FinishOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if(order.ValueFined <= 0)
            {
                throw new Exception("O Pedido não precisa ser pago, pois não houve multa para pagamento");
            }

            var paymentDTO = new PaymentsDTO(order.Id, request.CardNumber, request.DtExpired,request.FullName, order.ValueFined);

            var payment = await _paymentsService.ProcessPayment(paymentDTO);

            if (payment)
                order.FinishOrder();

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();

            return payment;
        }
    }
}
