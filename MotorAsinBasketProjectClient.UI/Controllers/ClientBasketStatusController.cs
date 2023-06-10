using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientBasketStatusController : Controller
    {
        private readonly ClientBasketStatusApiService _apiService;

        public ClientBasketStatusController(ClientBasketStatusApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
