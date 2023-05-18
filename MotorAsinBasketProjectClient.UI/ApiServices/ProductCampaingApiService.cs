using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketProjectClient.UI.ApiServices
{
    public class ProductCampaingApiService
    {
        private readonly HttpClient _httpClient;

        public ProductCampaingApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IList<ProductsCampaigns>> GetProductCampaingAllAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/ProductsCampaigns/GetList?IsActive=true");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IList<ProductsCampaigns>>();
            }
            else
            {
                // Handle the error
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
    }
}
