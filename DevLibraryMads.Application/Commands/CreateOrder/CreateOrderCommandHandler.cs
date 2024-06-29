using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Enums;
using DevLibraryMads.Core.Repositories;
using MediatR;

namespace DevLibraryMads.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //Verifico se o livro está disponível para o empréstimo
            var book = await _bookRepository.GetByIdAsync(request.Id_Book);
            if(book != null)
            {
                if(book.Status.Equals(StatusBookEnum.unavailable))
                {
                    throw new Exception("O Livro já está alugado.");
                }
            }

            var order = new Order(request.NumPedVda, request.Id_Client, request.Id_Book,request.ValueFined);

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            book.UpdateStatusBookUnavailable();

            await _bookRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync();



            return order.Id;
        }
    }
}
