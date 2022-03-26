using MicroCloud.Web.Models;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
