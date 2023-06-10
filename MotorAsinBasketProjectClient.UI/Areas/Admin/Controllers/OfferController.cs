using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.ApiServices;

namespace MotorAsinBasketProjectClient.UI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class OfferController : Controller
    {
        private readonly OfferApiService _offerApiService;

        public OfferController(OfferApiService offerApiService)
        {
            _offerApiService = offerApiService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
