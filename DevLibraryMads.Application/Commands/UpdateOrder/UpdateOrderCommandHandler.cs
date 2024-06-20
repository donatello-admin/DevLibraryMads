using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            DateTime dataNull = Convert.ToDateTime("0001-01-01 00:00:00.0000000");

            if (order.ReturnedAt != dataNull)
                return order.Id;

            order.ValueFined = order.IsFined(order.CreatedAt, request.ReturnedAt);
            order.Update(order.ValueFined, request.ReturnedAt);

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();

            var book = await _bookRepository.GetByIdAsync(order.Id_Book);
            book.UpdateStatusBookAvailable();

            await _bookRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync();

            return order.Id;


        }
    }
}
