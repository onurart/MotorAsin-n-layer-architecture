using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientCustomerController : Controller
    {
        private readonly ClientCustomersApiService _clientDocumentApiService;

        public ClientCustomerController(ClientCustomersApiService clientDocumentApiService)
        {
            _clientDocumentApiService = clientDocumentApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
