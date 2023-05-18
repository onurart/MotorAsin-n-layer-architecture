using Microsoft.AspNetCore.Mvc;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class ClientRepotsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
