using MicroCloud.Web.Models.FakePayments;
using MicroCloud.Web.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RecevicePayment(PaymentInfoInput paymentInfoInput)
        {
            var response = await _httpClient.PostAsJsonAsync("fakepayments", paymentInfoInput);

            return response.IsSuccessStatusCode;
        }
    }
}
