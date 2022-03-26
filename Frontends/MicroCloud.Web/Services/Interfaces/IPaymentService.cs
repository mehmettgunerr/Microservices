using MicroCloud.Web.Models.FakePayments;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> RecevicePayment(PaymentInfoInput paymentInfoInput);
    }
}
