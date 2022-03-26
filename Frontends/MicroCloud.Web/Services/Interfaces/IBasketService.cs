using MicroCloud.Web.Models.Baskets;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services.Interfaces
{
    public interface IBasketService
    {
        Task<bool> SaveOrBasket(BasketViewModel basketViewModel);
        Task<BasketViewModel> Get();
        Task<bool> Delete();
        Task AddBasketItem(BasketItemViewModel basketItemViewModel);
        Task<bool> RemoveBasketItem(string Id);
        Task<bool> ApplyDiscount(string discountCode);
        Task<bool> CancelApplyDiscount();
    }
}
