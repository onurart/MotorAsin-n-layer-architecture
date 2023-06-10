using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientDocumentController : Controller
    {
        private readonly ClientDocumentApiService _clientDocumentApiService;

        public ClientDocumentController(ClientDocumentApiService clientDocumentApiService)
        {
            _clientDocumentApiService = clientDocumentApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
