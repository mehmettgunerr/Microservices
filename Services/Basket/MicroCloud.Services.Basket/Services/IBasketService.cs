﻿using MicroCloud.Services.Basket.Dtos;
using MicroCloud.Shared.Dtos;
using System.Threading.Tasks;

namespace MicroCloud.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}