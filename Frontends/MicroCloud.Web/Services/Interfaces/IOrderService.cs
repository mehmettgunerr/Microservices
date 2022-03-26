using MicroCloud.Web.Models.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput);
        Task SuspendOrder(CheckoutInfoInput checkoutInfoInput);//asenkron çalışıp,sipariş bilgileri RabbitMQ ya gönderilecek.
        Task<List<OrderViewModel>> GetOrder();
    }
}
