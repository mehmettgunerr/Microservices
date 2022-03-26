using MicroCloud.Web.Models.Discounts;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
