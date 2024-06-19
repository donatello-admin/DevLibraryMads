using DevLibraryMads.Core.Enums;
using MediatR;

namespace DevLibraryMads.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public UpdateOrderCommand(int id)
        {
            Id = id;
            ReturnedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public string NumPedVda { get; private set; }
        public StatusOrderEnum StatusOrder { get; private set; }
        public decimal? ValueFined { get; set; }
        public int Id_Client { get; private set; }
        public int Id_Book { get; private set; }
        public DateTime ReturnedAt { get; set; }
    }
}
