using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientProductCampaingController : Controller
    {
        private readonly ProductCampaingApiService _productCampaingApiService;

        public ClientProductCampaingController(ProductCampaingApiService productCampaingApiService)
        {
            _productCampaingApiService = productCampaingApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
