using Microsoft.AspNetCore.Mvc;

namespace MotorAsinBasketProjectClient.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
