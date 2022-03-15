using MicroCloud.Services.Catalog.Dtos;
using MicroCloud.Services.Catalog.Models;
using MicroCloud.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroCloud.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
