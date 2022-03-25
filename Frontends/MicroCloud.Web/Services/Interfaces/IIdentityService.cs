using IdentityModel.Client;
using MicroCloud.Shared.Dtos;
using MicroCloud.Web.Models;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
