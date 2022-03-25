using System.Threading.Tasks;

namespace MicroCloud.Web.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
