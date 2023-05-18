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


        /// <summary>
        /// Parametsiz Olam GetList
        /// </summary>
        /// <returns></returns>

        //public async Task<List<Offer>> GetOfferAllAsync()
        //{
        //    var response = await _httpClient.GetFromJsonAsync<List<Offer>>("Offer/GetList");
        //    return response;
        //}


        public async Task<IList<Offer>> GetOfferAllAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/Offer/GetList?IsActive=true");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IList<Offer>>();
            }
            else
            {
                // Handle the error
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
       
    }
}
