using MotorAsinBasketRobot.Entities.Concrete;

namespace MotorAsinBasketProjectClient.UI.ApiServices
{
    public class ClientDocumentApiService
    {
        private readonly HttpClient _httpClient;

        public ClientDocumentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //public async Task<IList<Documents>> GetClientDocumentllAsync()
        //{
        //    HttpClient client = new HttpClient();

        //    HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/Document/GetList?IsActive=true");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadFromJsonAsync<IList<Documents>>();
        //    }
        //    else
        //    {
        //        // Handle the error
        //        throw new Exception($"API request failed with status code {response.StatusCode}");
        //    }
        //}

        public async Task<IList<Documents>> GetClientDocumentllAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7059/api/Document/GetList?IsActive=true");

            if (response.IsSuccessStatusCode)
            {
                var documents = await response.Content.ReadFromJsonAsync<IList<Documents>>();
                return documents;
            }
            else
            {
                // Handle the error
                throw new Exception($"API request failed with status code {response.StatusCode}");
            }
        }
    }
}
