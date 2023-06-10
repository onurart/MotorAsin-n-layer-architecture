using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketRobot.Entities.Dtos.Product;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientProductController : Controller
    {
        private readonly ClientProductApiService _clientProductApiService;

        public ClientProductController(ClientProductApiService clientProductApiService)
        {
            _clientProductApiService = clientProductApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
