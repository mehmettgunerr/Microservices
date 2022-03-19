using Dapper;
using MicroCloud.Shared.Dtos;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MicroCloud.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select * from discount");

            return Response<List<Models.Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("Select * from discount where code = @Code and userid =@UserId", new { Code = code, UserId = userId })).SingleOrDefault();

            if (discount == null)
                return Response<Models.Discount>.Fail("Discount not found", 404);

            return Response<Models.Discount>.Success(discount, 200);
        }

        public async Task<Response<Models.Discount>> GetById(int Id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("Select * from discount where Id = @Id", new { Id = Id })).SingleOrDefault();

            if (discount == null)
                return Response<Models.Discount>.Fail("Discount not found", 404);

            return Response<Models.Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var saveStatus = await _dbConnection.ExecuteAsync("Insert Into discount(userid,rate,code) Values(@UserId,@Rate,@Code)", discount);

            if (saveStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("an error occurred while addding", 500);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            //update edelecek data kontrolü yapıabilir

            var updateStatus = await _dbConnection.ExecuteAsync("update discount set userid = @UserId, rate = @Rate, code = @Code where Id=@Id", discount);

            if (updateStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("discount not found", 500);
        }

        public async Task<Response<NoContent>> Delete(int Id)
        {
            var deleteStatus = await _dbConnection.ExecuteAsync("delete from discount where Id=@Id", new { Id = Id });

            if (deleteStatus > 0)
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("discount not found", 404);
        }
    }
}
