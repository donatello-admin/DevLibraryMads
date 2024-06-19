using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public UpdateOrderCommand(int id, DateTime returnedAt)
        {
            Id = id;
            ReturnedAt = returnedAt;
        }

        public int Id { get; private set; }
        public DateTime ReturnedAt { get; set; }
    }
}
