using MicroCloud.Shared.Dtos;
using MicroCloud.Web.Models.PhotoStocks;
using MicroCloud.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MicroCloud.Web.Services
{
    public class PhotoStockService : IPhotoStockService
    {
        private readonly HttpClient _client;

        public PhotoStockService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> DeletePhoto(string photoUrl)
        {
            var response = await _client.DeleteAsync($"photos?photoUrl={photoUrl}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PhotoViewModel> UploadPhoto(IFormFile photo)
        {
            if (photo == null || photo.Length <= 0)
                return null;

            var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";

            using var ms = new MemoryStream();

            await photo.CopyToAsync(ms);

            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new ByteArrayContent(ms.ToArray()), "photo", randomFileName);

            var response = await _client.PostAsync("photos", multipartContent);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess =  await response.Content.ReadFromJsonAsync<Response<PhotoViewModel>>();

            return responseSuccess.Data;
        }
    }
}
