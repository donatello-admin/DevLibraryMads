using DevLibraryMads.Core.Enums;
using MediatR;

namespace DevLibraryMads.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int Id { get; private set; }
        public string NumPedVda { get;  set; }
        private StatusOrderEnum StatusOrder { get; set; }
        public decimal ValueFined { get; private set; }
        public int Id_Client { get; set; }
        public int Id_Book { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ReturnedAt { get; private set; }
    }
}
