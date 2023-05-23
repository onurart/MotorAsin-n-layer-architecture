using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketProjectClient.UI.ApiServices
{
    public class IncomingOrderRequestsApiSevice
    {
        private readonly HttpClient _httpClient;

        public IncomingOrderRequestsApiSevice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IList<IncomingOrderRequests>> GetIncomingOrderRequestsAllAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/IncomingOrderRequest/GetList?Statu=true&IsActive=true");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IList<IncomingOrderRequests>>();
            }
            else
            {
                // Handle the error
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
    }
}
