using DevLibraryMads.Core.DTOs;

namespace DevLibraryMads.Core.Services
{
    public interface IPaymentsService
    {
        public Task<bool> ProcessPayment(PaymentsDTO paymentsDTO);
    }
}
