using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class OrderDemandController : Controller
    {
        private readonly IncomingOrderRequestsApiSevice _apiService;

        public OrderDemandController(IncomingOrderRequestsApiSevice apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var productCampaingApiService = await _apiService.GetIncomingOrderRequestsAllAsync();

            return View(productCampaingApiService);
        }
    }
}
