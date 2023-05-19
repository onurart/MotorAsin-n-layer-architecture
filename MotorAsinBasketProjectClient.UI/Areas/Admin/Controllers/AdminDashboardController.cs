using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotorAsinBasketProjectClient.UI.Areas.Admin.Controllers
{

    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
