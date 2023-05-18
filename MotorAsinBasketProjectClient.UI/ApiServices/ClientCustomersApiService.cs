using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketProjectClient.UI.ApiServices
{
    public class ClientCustomersApiService
    {
        private readonly HttpClient _httpClient;

        public ClientCustomersApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IList<Customer>> GetClientustomerllAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/Customer/GetList?IsActive=true");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IList<Customer>>();
            }
            else
            {
                // Handle the error
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
    }
}
