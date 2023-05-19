using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketProjectClient.UI.ApiServices
{
    public class ClientProductApiService
    {
        private readonly HttpClient _httpClient;

        public ClientProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IList<Product>> GetProductAllAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/Product/GetList?IsActive=true");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IList<Product>>();
            }
            else
            {
                // Handle the error
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
        }
}
