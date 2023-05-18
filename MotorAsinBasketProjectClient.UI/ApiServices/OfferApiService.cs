using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Offer;
using System.Text.Json;

namespace MotorAsinBasketProjectClient.UI.ApiServices
{
    public class OfferApiService
    {
        private readonly HttpClient _httpClient;

        public OfferApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<OfferListPramertDto>> GetOfferAllAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7059/api/Offer/GetList?Statu=true&IsActive=true");
            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync(); 
            return JsonSerializer.Deserialize<List<OfferListPramertDto>>(data);
        }
        //public async  Task<List<OfferListPramertDto>> GetOfferAllAsync()
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<OfferListPramertDto>>>("Offer/GetList");
        //        return response.Data;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
