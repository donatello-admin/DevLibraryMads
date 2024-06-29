using DevLibraryMads.Core.DTOs;
using DevLibraryMads.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text;

namespace DevLibraryMads.Infrastructure.Payments
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentsBaseUrl;

        public PaymentsService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
        }

        public async Task<bool> ProcessPayment(PaymentsDTO paymentsDTO)
        {
            var url = $"{_paymentsBaseUrl}/api/payments";
            var paymentJson = JsonSerializer.Serialize(paymentsDTO);

            var paymentInfoContent = new StringContent(
                paymentJson,
                Encoding.UTF8,
                "application/json"
                );

            var httpClient = _httpClientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;
        }
    }
}
