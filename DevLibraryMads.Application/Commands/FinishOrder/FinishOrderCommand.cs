using MediatR;

namespace DevLibraryMads.Application.Commands.FinishOrder
{
    public class FinishOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string DtExpired { get; set; }
        public string FullName { get; set; }
    }
}
