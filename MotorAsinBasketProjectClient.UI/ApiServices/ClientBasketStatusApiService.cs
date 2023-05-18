using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketProjectClient.UI.ApiServices
{
    public class ClientBasketStatusApiService
    {
        private readonly HttpClient _httpClient;

        public ClientBasketStatusApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IList<BasketStatus>> GetProductBasketStatusAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/BasketStatus/GetList?IsActive=true");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IList<BasketStatus>>();
            }
            else
            {
                // Handle the error
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
    }
}
